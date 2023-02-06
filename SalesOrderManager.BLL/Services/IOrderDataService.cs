using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Services
{
    public interface IOrderDataService
    {
        Task<IEnumerable<Order>> GetAllOrders(bool refreshRequired = false);
        Task<Order> GetOrderDetails(int? orderId);
        Task<Order> AddOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int orderId);
    }
}
