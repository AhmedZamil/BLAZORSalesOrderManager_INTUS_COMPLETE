using Microsoft.AspNetCore.Components;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Components
{
    public partial class OrderCard
    {
        [Parameter]
        public Order Order { get; set; } = default!;

        [Parameter]
        public EventCallback<Order> OrderQuickViewClicked { get; set; }

        [Parameter]
        public EventCallback<Order> OrderRemoveClicked { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            if (string.IsNullOrEmpty(Order.Name))
            {
                throw new Exception("Name can't be empty");
            }
        }

        public void NavigateToDetails(Order selectedOrder)
        {

            NavigationManager.NavigateTo($"/orderdetail/{selectedOrder.OrderId}");

        }
    }
}
