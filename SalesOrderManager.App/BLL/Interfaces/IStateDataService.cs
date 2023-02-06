using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.BLL.Interfaces
{
    public interface IStateDataService
    {
        Task<IEnumerable<SalesOrderManager.Shared.Domain.State>> GetAllStates();
        Task<SalesOrderManager.Shared.Domain.State> GetStateById(int countryId);
    }
}
