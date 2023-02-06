using Microsoft.AspNetCore.Components;
using SalesOrderManager.BLL;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Pages
{
    public partial class WindowDetail
    {
        [Parameter]
        public string WindowId { get; set; }
        public Window Window { get; set; } = new Window();
        public Order Order { get; set; } = new Order();
        public int? OrderId { get; set; }

        public List<SubElement> SubElements { get; set; } = default!;
        private SubElement? _selectedSubElement;

        [Inject]
        public IWindowDataService? WindowDataService { get; set; }

        [Inject]
        public IOrderDataService? OrderDataService { get; set; }

        [Inject]
        public ISubElementDataService? SubElementDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Window = await WindowDataService.GetWindowDetails(int.Parse(WindowId));
            if (Window?.OrderId == null || Window?.OrderId == 0)
            {
                OrderId = 0;
            }
            else
            {
                OrderId =Window.OrderId;
            }
            Order = await OrderDataService.GetOrderDetails(OrderId);
            SubElements = (await SubElementDataService.GetAllSubElementsByWindowId(int.Parse(WindowId))).ToList();
        }

        public void ShowQuickSubElementViewPopup(SubElement selectedSubElement)
        {
            _selectedSubElement = selectedSubElement;
        }

        protected void NavigateToOrderDetails()
        {
            if (Window?.OrderId > 0)
            {
                NavigationManager.NavigateTo($"/orderdetail/{Window.OrderId}");
            }
            else {
                NavigationManager.NavigateTo($"/windowoverview");
            }

        }
    }
}
