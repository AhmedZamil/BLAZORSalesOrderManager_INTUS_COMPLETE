using System.Text.Json;

namespace SalesOrderManager.BLL
{
    public class StateDataService : IStateDataService
    {
        private readonly HttpClient _httpClient = default!;

        public StateDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SalesOrderManager.Shared.Domain.State>> GetAllStates()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<SalesOrderManager.Shared.Domain.State>>
                (await _httpClient.GetStreamAsync($"api/state"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<SalesOrderManager.Shared.Domain.State> GetStateById(int stateId)
        {
            return await JsonSerializer.DeserializeAsync<SalesOrderManager.Shared.Domain.State>
                (await _httpClient.GetStreamAsync($"api/state{stateId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
