using Microsoft.AspNetCore.Components;
using SalesOrderManager.App.BLL.Interfaces;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Pages
{
    public partial class SubElementOverview
    {
        public List<SubElement> SubElements { get; set; } = default!;
        private SubElement? _selectedSubElement;

        private string Title = "Sub Element overview";
        private string Description = "Sub Element overview";

        [Inject]
        public ISubElementDataService? SubElementDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            SubElements = (await SubElementDataService.GetAllSubElements()).ToList();
        }

        public void ShowQuickSubElementViewPopup(SubElement selectedSubElement)
        {
            _selectedSubElement = selectedSubElement;
        }
    }
}
