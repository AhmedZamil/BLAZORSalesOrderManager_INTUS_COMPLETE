using Microsoft.AspNetCore.Components;
using SalesOrderManager.App.BLL.Interfaces;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Pages
{
    public partial class OrderDetail
    {
        [Parameter]
        public string OrderId { get; set; }

        [Parameter]
        //public string? CrudEnable { get; set; }
        public Order Order { get; set; } = new Order();

        public List<Window> Windows { get; set; } = default!;
        private Window? _selectedWindow;

        [Inject]
        public IOrderDataService? OrderDataService { get; set; }

        [Inject]
        public IWindowDataService? WindowDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //bool.TryParse(CrudEnable, out var crud);
            Order = await OrderDataService.GetOrderDetails(int.Parse(OrderId));
            Windows = (await WindowDataService.GetAllWindowsByOrderId(int.Parse(OrderId))).ToList();
        }

        public void ShowQuickWindowViewPopup(Window selectedWindow)
        {
            _selectedWindow = selectedWindow;
        }

        protected async Task DeleteWindow(Window selectedWindow)
        {
            await WindowDataService.DeleteWindow(selectedWindow.WindowId);
            Windows = (await WindowDataService.GetAllWindowsByOrderId(int.Parse(OrderId))).ToList();

        }

        protected void NavigateToOrderDetails()
        {
            NavigationManager.NavigateTo($"/orderoverview");

        }

    }
}
