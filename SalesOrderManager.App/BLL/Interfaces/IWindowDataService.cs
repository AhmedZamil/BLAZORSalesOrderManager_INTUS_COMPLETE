using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.BLL.Interfaces
{
    public interface IWindowDataService
    {
        Task<IEnumerable<Window>> GetAllWindows(bool refreshRequired = false);

        Task<IEnumerable<Window>> GetAllWindowsByOrderId(int orderId, bool refreshRequired = false);
        Task<Window> GetWindowDetails(int? orderId);
        Task<Window> AddWindow(Window window);
        Task UpdateWindow(Window window);
        Task DeleteWindow(int windowId);
    }
}
