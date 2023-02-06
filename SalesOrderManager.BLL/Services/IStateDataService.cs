using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Services
{
    public interface IStateDataService
    {
        Task<IEnumerable<SalesOrderManager.Shared.Domain.State>> GetAllStates();
        Task<SalesOrderManager.Shared.Domain.State> GetStateById(int countryId);
    }
}
