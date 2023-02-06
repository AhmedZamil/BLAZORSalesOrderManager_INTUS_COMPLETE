using SalesOrderManager.DAL;

namespace SalesOrderManager.DAL
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _appDbContext;

        public StateRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<SalesOrderManager.Shared.Domain.State> GetAllStates()
        {
            return _appDbContext.States;
        }

        public SalesOrderManager.Shared.Domain.State GetStateById(int stateId)
        {
            return _appDbContext.States.FirstOrDefault(c => c.StateId == stateId);
        }
    }
}
