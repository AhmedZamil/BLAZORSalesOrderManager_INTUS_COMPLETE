using Microsoft.AspNetCore.Components;
using SalesOrderManager.BLL;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Components.Widgets
{
    public partial class OrderCountWidget
    {
        public int? OrderCounter { get; set; }

        public List<Order> NewOrders { get; set; } = new List<Order>();

        [Inject]
        public IOrderDataService OrderDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            NewOrders = (await OrderDataService.GetAllOrders()).ToList();
            OrderCounter = NewOrders?.Count();
        }
    }
}
