using Microsoft.AspNetCore.Components;
using SalesOrderManager.BLL;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Pages
{
    public partial class SubElementDetail
    {
        [Parameter]
        public string SubElementId { get; set; }
        public SubElement SubElement { get; set; } = new SubElement();

        public Window Window { get; set; } = new Window();
        public int? WindowId { get; set; }

        [Inject]
        public ISubElementDataService? SubElementDataService { get; set; }

        [Inject]
        public IWindowDataService? WindowDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            SubElement = await SubElementDataService.GetSubElementDetails(int.Parse(SubElementId));
            if (SubElement?.WindowId == null || SubElement?.WindowId == 0)
            {
                WindowId = 0;
            }
            else
            {
                WindowId = SubElement?.WindowId;
            }
            Window = await WindowDataService.GetWindowDetails(WindowId);
        }

        protected void NavigateToWindowDetails()
        {
            if (SubElement?.WindowId > 0)
            {
                NavigationManager.NavigateTo($"/windowdetail/{SubElement.WindowId}");
            }
            else
            {
                NavigationManager.NavigateTo($"/subelementoverview");
            }

        }
    }
}
