using Blazored.LocalStorage;
using SalesOrderManager.App.Helper;
using SalesOrderManager.Shared.Domain;
using System.Text;
using System.Text.Json;

namespace SalesOrderManager.App.Services
{
    public class SubElementDataService : ISubElementDataService
    {
        private readonly HttpClient? _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public SubElementDataService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task<SubElement> AddSubElement(SubElement subElement)
        {
            var subElementJson =
                new StringContent(JsonSerializer.Serialize(subElement), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/subelement", subElementJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<SubElement>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteSubElement(int subelEmentId)
        {
            await _httpClient.DeleteAsync($"api/subelement/{subelEmentId}");
        }

        public async Task UpdateSubElement(SubElement subElement)
        {
            var subElementJson =
                new StringContent(JsonSerializer.Serialize(subElement), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/subelement", subElementJson);
        }

        public async Task<IEnumerable<SubElement>> GetAllSubElements(bool refreshRequired = false)
        {
            if (refreshRequired)
            {
                bool subElementExpirationExists = await _localStorageService.ContainKeyAsync(LocalStorageConstants.SubElementsListExpirationKey);
                if (subElementExpirationExists)
                {
                    DateTime orderListExpiration = await _localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.SubElementsListExpirationKey);
                    if (orderListExpiration > DateTime.Now)//get from local storage
                    {
                        if (await _localStorageService.ContainKeyAsync(LocalStorageConstants.SubElementsListKey))
                        {
                            return await _localStorageService.GetItemAsync<List<SubElement>>(LocalStorageConstants.SubElementsListKey);
                        }
                    }
                }
            }

            //otherwise refresh the list locally from the API and set expiration to 1 minute in future

            var list = await JsonSerializer.DeserializeAsync<IEnumerable<SubElement>>
                    (await _httpClient.GetStreamAsync($"api/subelement"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            await _localStorageService.SetItemAsync(LocalStorageConstants.SubElementsListKey, list);
            await _localStorageService.SetItemAsync(LocalStorageConstants.SubElementsListExpirationKey, DateTime.Now.AddMinutes(1));

            return list;
        }


        public async Task<IEnumerable<SubElement>> GetAllSubElementsByWindowId(int windowId, bool refreshRequired = false)
        {
            if (refreshRequired)
            {
                bool subElementExpirationExists = await _localStorageService.ContainKeyAsync(LocalStorageConstants.SubElementsListExpirationKey);
                if (subElementExpirationExists)
                {
                    DateTime orderListExpiration = await _localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.SubElementsListExpirationKey);
                    if (orderListExpiration > DateTime.Now)//get from local storage
                    {
                        if (await _localStorageService.ContainKeyAsync(LocalStorageConstants.SubElementsListByWindowIdKey))
                        {
                            return await _localStorageService.GetItemAsync<List<SubElement>>(LocalStorageConstants.SubElementsListByWindowIdKey);
                        }
                    }
                }
            }

            //otherwise refresh the list locally from the API and set expiration to 1 minute in future

            var list = await JsonSerializer.DeserializeAsync<IEnumerable<SubElement>>
                    (await _httpClient.GetStreamAsync($"api/subelement/getbywindowid?windowid={windowId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            await _localStorageService.SetItemAsync(LocalStorageConstants.SubElementsListByWindowIdKey, list);
            await _localStorageService.SetItemAsync(LocalStorageConstants.SubElementsListExpirationKey, DateTime.Now.AddMinutes(1));

            return list;
        }


        public async Task<SubElement> GetSubElementDetails(int subElementId)
        {
            return await JsonSerializer.DeserializeAsync<SubElement>
                (await _httpClient.GetStreamAsync($"api/subelement/{subElementId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


    }
}
