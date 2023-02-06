namespace SalesOrderManager.DAL
{
    public interface IStateRepository
    {
        IEnumerable<SalesOrderManager.Shared.Domain.State> GetAllStates();
        SalesOrderManager.Shared.Domain.State GetStateById(int stateId);
    }
}
