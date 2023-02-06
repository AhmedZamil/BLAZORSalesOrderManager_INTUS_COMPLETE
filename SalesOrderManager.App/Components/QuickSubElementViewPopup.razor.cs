using Microsoft.AspNetCore.Components;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Components
{
    public partial class QuickSubElementViewPopup
    {
        private SubElement? _subElement;

        [Parameter]
        public SubElement? SubElement { get; set; }

        protected override void OnParametersSet()
        {
            _subElement = SubElement;

        }

        public void Close()
        {
            _subElement = null;
        }
    }
}
