using Microsoft.EntityFrameworkCore;
using SalesOrderManager.DAL;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.DAL
{
    public class SubElementRepository : ISubElementRepository
    {
        private readonly AppDbContext _appDbContext;

        public SubElementRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public SubElement AddSubElement(SubElement subElement)
        {
            var addedEntity = _appDbContext.SubElements.Add(subElement);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void DeleteSubElement(int subElementId)
        {
            var foundSubElement = _appDbContext.SubElements.FirstOrDefault(e => e.SubElementId == subElementId);
            if (foundSubElement == null) return;

            _appDbContext.SubElements.Remove(foundSubElement);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<SubElement> GetAllSubElements()
        {
            return _appDbContext.SubElements;
        }

        public IEnumerable<SubElement> GetAllSubElementsByWindowId(int windowId)
        {
            return _appDbContext.SubElements.Where(m => m.WindowId == windowId);
        }

        public SubElement GetSubElementById(int subElementId)
        {
            return _appDbContext.SubElements.FirstOrDefault(c => c.SubElementId == subElementId);
        }

        public SubElement UpdateSubElement(SubElement subElement)
        {
            var foundSubElement = _appDbContext.SubElements.FirstOrDefault(e => e.SubElementId == subElement.SubElementId);

            if (foundSubElement != null)
            {
                foundSubElement.Element = subElement.Element;
                foundSubElement.Width = subElement.Width;
                foundSubElement.Height = subElement.Height;
                _appDbContext.SaveChanges();

                return foundSubElement;
            }

            return null;
        }


    }
}
