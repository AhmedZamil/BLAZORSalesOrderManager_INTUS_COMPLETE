using Microsoft.AspNetCore.Components;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Components
{
    public partial class QuickWindowViewPopup
    {
        private Window? _window;

        [Parameter]
        public Window? Window { get; set; }

        protected override void OnParametersSet()
        {
            _window = Window;

        }

        public void Close()
        {
            _window = null;
        }
    }
}
