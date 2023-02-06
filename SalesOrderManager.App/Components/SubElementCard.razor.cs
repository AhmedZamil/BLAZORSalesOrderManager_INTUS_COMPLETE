using Microsoft.AspNetCore.Components;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Components
{
    public partial class SubElementCard
    {
        [Parameter]
        public SubElement SubElement { get; set; } = default!;

        [Parameter]
        public EventCallback<SubElement> SubElementQuickViewClicked { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            if (string.IsNullOrEmpty(SubElement.ElementType.ToString()))
            {
                throw new Exception("SubElement type can't be empty");
            }
        }

        public void NavigateToDetails(SubElement selectedSubElement)
        {

            NavigationManager.NavigateTo($"/subelementdetail/{selectedSubElement.SubElementId}");

        }
    }
}
