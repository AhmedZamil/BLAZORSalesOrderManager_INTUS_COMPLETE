using Microsoft.AspNetCore.Components;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Components
{
    public partial class QuickOrderViewPopup
    {
        private Order? _order;

        [Parameter]
        public Order? Order { get; set; }

        protected override void OnParametersSet()
        {
            _order = Order;

        }

        public void Close()
        {
            _order = null;
        }
    }
}
