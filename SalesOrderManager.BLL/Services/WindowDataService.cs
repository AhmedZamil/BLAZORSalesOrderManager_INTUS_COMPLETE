using Blazored.LocalStorage;
using SalesOrderManager.App.Helper;
using SalesOrderManager.Shared.Domain;
using System.Text;
using System.Text.Json;

namespace SalesOrderManager.App.Services
{
    public class WindowDataService : IWindowDataService
    {
        private readonly HttpClient? _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public WindowDataService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }
        public async Task<Window> AddWindow(Window window)
        {
            var windowJson = new StringContent(JsonSerializer.Serialize(window), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/window", windowJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Window>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteWindow(int windowId)
        {
            await _httpClient.DeleteAsync($"api/window/{windowId}");
        }

        public async Task UpdateWindow(Window window)
        {
            var windowJson = new StringContent(JsonSerializer.Serialize(window), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/window", windowJson);
        }

        public async Task<IEnumerable<Window>> GetAllWindows(bool refreshRequired = false)
        {
            if (refreshRequired)
            {
                bool windowExpirationExists = await _localStorageService.ContainKeyAsync(LocalStorageConstants.WindowsListExpirationKey);
                if (windowExpirationExists)
                {
                    DateTime windowListExpiration = await _localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.WindowsListExpirationKey);
                    if (windowListExpiration > DateTime.Now)//get from local storage
                    {
                        if (await _localStorageService.ContainKeyAsync(LocalStorageConstants.WindowsListKey))
                        {
                            return await _localStorageService.GetItemAsync<List<Window>>(LocalStorageConstants.WindowsListKey);
                        }
                    }
                }
            }

            //otherwise refresh the list locally from the API and set expiration to 1 minute in future

            var list = await JsonSerializer.DeserializeAsync<IEnumerable<Window>>
                    (await _httpClient.GetStreamAsync($"api/window"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            await _localStorageService.SetItemAsync(LocalStorageConstants.WindowsListKey, list);
            await _localStorageService.SetItemAsync(LocalStorageConstants.WindowsListExpirationKey, DateTime.Now.AddMinutes(1));

            return list;
        }


        public async Task<IEnumerable<Window>> GetAllWindowsByOrderId(int orderId, bool refreshRequired = false)
        {
            if (refreshRequired && orderId > 0)
            {
                bool windowExpirationExists = await _localStorageService.ContainKeyAsync(LocalStorageConstants.WindowsListExpirationKey);
                if (windowExpirationExists)
                {
                    DateTime windowListExpiration = await _localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.WindowsListExpirationKey);
                    if (windowListExpiration > DateTime.Now)//get from local storage
                    {
                        if (await _localStorageService.ContainKeyAsync(LocalStorageConstants.WindowsListByOrderIdKey))
                        {
                            return await _localStorageService.GetItemAsync<List<Window>>(LocalStorageConstants.WindowsListByOrderIdKey);
                        }
                    }
                }
            }

            //otherwise refresh the list locally from the API and set expiration to 1 minute in future

            var list = await JsonSerializer.DeserializeAsync<IEnumerable<Window>>
                    (await _httpClient.GetStreamAsync($"api/window/getbyorderid?orderId={orderId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            await _localStorageService.SetItemAsync(LocalStorageConstants.WindowsListByOrderIdKey, list);
            await _localStorageService.SetItemAsync(LocalStorageConstants.WindowsListExpirationKey, DateTime.Now.AddMinutes(1));

            return list;
        }


        public async Task<Window> GetWindowDetails(int? windowId)
        {
            return await JsonSerializer.DeserializeAsync<Window>
                (await _httpClient.GetStreamAsync($"api/window/{windowId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

    }
}
