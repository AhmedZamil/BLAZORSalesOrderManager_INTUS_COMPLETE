using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.BLL
{
    public interface ISubElementDataService
    {
        Task<IEnumerable<SubElement>> GetAllSubElements(bool refreshRequired = false);
        Task<IEnumerable<SubElement>> GetAllSubElementsByWindowId(int windowId, bool refreshRequired = false);
        Task<SubElement> GetSubElementDetails(int subelEmentId);
        Task<SubElement> AddSubElement(SubElement subElement);
        Task UpdateSubElement(SubElement subElement);
        Task DeleteSubElement(int subelEmentId);
    }
}
