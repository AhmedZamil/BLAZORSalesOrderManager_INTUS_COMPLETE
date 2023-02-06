using Microsoft.AspNetCore.Components;
using SalesOrderManager.App.BLL.Interfaces;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Pages
{
    public partial class WindowOverview
    {
        public List<Window> Windows { get; set; } = default!;
        private Window? _selectedWindow;

        private string Title = "Windowa overview";
        private string Description = "windowsa overview";

        [Inject]
        public IWindowDataService? WindowDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Windows = (await WindowDataService.GetAllWindows()).ToList();
        }

        public void ShowQuickWindowViewPopup(Window selectedWindow)
        {
            _selectedWindow = selectedWindow;
        }
    }
}
