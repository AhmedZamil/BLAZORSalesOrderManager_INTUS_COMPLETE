using Microsoft.AspNetCore.Components;
using SalesOrderManager.App.BLL.Interfaces;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Components
{
    public partial class NewOrderCard
    {
        public List<Order> NewOrders { get; set; } = new List<Order>();

        [Inject]
        public IOrderDataService OrderDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            NewOrders = (await OrderDataService.GetAllOrders()).OrderBy(x => x.Name).Take(3).ToList();
        }
    }
}
