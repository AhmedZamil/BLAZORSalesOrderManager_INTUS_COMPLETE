using Microsoft.AspNetCore.Components;
using SalesOrderManager.App.BLL.Interfaces;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Pages
{
    public partial class OrderOverview
    {
        public List<Order> Orders { get; set; } = default!;
        private Order? _selectedOrder;

        private string Title = "Order overview";
        private string Description = "order overview";

        [Inject]
        public IOrderDataService? OrderDataService { get; set; }



        //protected override void OnInitialized()
        //{
        //    Employees = MockDataService.Employees;
        //}

        protected async override Task OnInitializedAsync()
        {
            Orders = (await OrderDataService.GetAllOrders()).ToList();
        }

        public void ShowQuickOrderViewPopup(Order selectedOrder)
        {
            _selectedOrder = selectedOrder;
        }

        protected async Task DeleteOrder(Order selectedOrder)
        {
            await OrderDataService.DeleteOrder(selectedOrder.OrderId);
            Orders = (await OrderDataService.GetAllOrders()).ToList();

        }
    }
}
