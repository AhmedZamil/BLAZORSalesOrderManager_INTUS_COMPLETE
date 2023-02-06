using Microsoft.EntityFrameworkCore;
using SalesOrderManager.DAL;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.DAL
{
    public class WindowRepository : IWindowRepository
    {
        private readonly AppDbContext _appDbContext;

        public WindowRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Window AddWindow(Window window)
        {
            var addedEntity = _appDbContext.Windows.Add(window);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void DeleteWindow(int windowId)
        {
            var foundWindow = _appDbContext.Windows.FirstOrDefault(e => e.WindowId == windowId);
            if (foundWindow == null) return;

            _appDbContext.Windows.Remove(foundWindow);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Window> GetAllWindows()
        {
            return _appDbContext.Windows.Include(w => w.SubElements);
        }

        public IEnumerable<Window> GetAllWindowsByOrderId(int orderId)
        {
            return _appDbContext.Windows.Include(w => w.SubElements).Where(m=>m.OrderId == orderId);
        }

        public Window GetWindowById(int windowId)
        {
            return _appDbContext.Windows.Include(w => w.SubElements).FirstOrDefault(c => c.WindowId == windowId);
        }

        public Window UpdateWindow(Window window)
        {
            var foundWindow = _appDbContext.Windows.FirstOrDefault(e => e.WindowId == window.WindowId);

            if (foundWindow != null)
            {
                foundWindow.Name = window.Name;
                foundWindow.QuantityOfWindows = window.QuantityOfWindows;
                foundWindow.TotalSubElements = window.TotalSubElements;
                _appDbContext.SaveChanges();

                return foundWindow;
            }

            return null;
        }
    }
}
