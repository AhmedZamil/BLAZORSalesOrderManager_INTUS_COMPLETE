using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.BLL
{
    public interface IStateDataService
    {
        Task<IEnumerable<SalesOrderManager.Shared.Domain.State>> GetAllStates();
        Task<SalesOrderManager.Shared.Domain.State> GetStateById(int countryId);
    }
}
