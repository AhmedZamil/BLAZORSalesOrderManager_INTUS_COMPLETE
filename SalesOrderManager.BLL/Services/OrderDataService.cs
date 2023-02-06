using Blazored.LocalStorage;
using SalesOrderManager.BLL;
using SalesOrderManager.Shared.Domain;
using System.Text;
using System.Text.Json;

namespace SalesOrderManager.BLL
{
    public class OrderDataService : IOrderDataService
    {
        private readonly HttpClient? _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public OrderDataService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }
        public async Task<Order> AddOrder(Order order)
        {
            var orderJson = new StringContent(JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/order", orderJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Order>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteOrder(int orderId)
        {
            await _httpClient.DeleteAsync($"api/order/{orderId}");
        }

        public async Task UpdateOrder(Order order)
        {
            var orderJson = new StringContent(JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/order", orderJson);
        }

        public async Task<IEnumerable<Order>> GetAllOrders(bool refreshRequired = false)
        {
            if (refreshRequired)
            {
                bool orderExpirationExists = await _localStorageService.ContainKeyAsync(LocalStorageConstants.OrdersListExpirationKey);
                if (orderExpirationExists)
                {
                    DateTime orderListExpiration = await _localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.OrdersListExpirationKey);
                    if (orderListExpiration > DateTime.Now)//get from local storage
                    {
                        if (await _localStorageService.ContainKeyAsync(LocalStorageConstants.OrdersListKey))
                        {
                            return await _localStorageService.GetItemAsync<List<Order>>(LocalStorageConstants.OrdersListKey);
                        }
                    }
                }
            }

            //otherwise refresh the list locally from the API and set expiration to 1 minute in future

            var list = await JsonSerializer.DeserializeAsync<IEnumerable<Order>>
                    (await _httpClient.GetStreamAsync($"api/order"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            await _localStorageService.SetItemAsync(LocalStorageConstants.OrdersListKey, list);
            await _localStorageService.SetItemAsync(LocalStorageConstants.OrdersListExpirationKey, DateTime.Now.AddMinutes(1));

            return list;
        }


        public async Task<Order> GetOrderDetails(int? orderId)
        {
            return await JsonSerializer.DeserializeAsync<Order>
                (await _httpClient.GetStreamAsync($"api/order/{orderId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
