using Microsoft.EntityFrameworkCore;
using SalesOrderManager.DAL;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public OrderRepository(IDbContextFactory<AppDbContext> contextFactory,AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _contextFactory = contextFactory;
        }
        public Order AddOrder(Order order)
        {
            if (order.State.StateId == 0)
            {
                order.State = null;
            }
            var addedEntity = _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void DeleteOrder(int orderId)
        {
            var foundOrder = _appDbContext.Orders.FirstOrDefault(e => e.OrderId == orderId);
            if (foundOrder == null) return;

            _appDbContext.Orders.Remove(foundOrder);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _appDbContext.Orders.Include(m=>m.State).Include(o=>o.Windows).ThenInclude(w=>w.SubElements);
        }

        public Order GetOrderById(int orderId)
        {
            return _appDbContext.Orders.Include(m => m.State).Include(o => o.Windows).ThenInclude(w => w.SubElements).FirstOrDefault(c => c.OrderId == orderId);
        }

        public Order UpdateOrder(Order order)
        {
            var foundOrder = _appDbContext.Orders.FirstOrDefault(e => e.OrderId == order.OrderId);

            if (foundOrder != null)
            {
                foundOrder.StateId = order.StateId;
                foundOrder.Name = order.Name;
                _appDbContext.SaveChanges();

                return foundOrder;
            }

            return null;
        }
    }
}
