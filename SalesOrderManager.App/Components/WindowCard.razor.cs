using Microsoft.AspNetCore.Components;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Components
{
    public partial class WindowCard
    {
        [Parameter]
        public Window Window { get; set; } = default!;

        [Parameter]
        public EventCallback<Window> WindowQuickViewClicked { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        //protected override void OnInitialized()
        //{
        //    if (string.IsNullOrEmpty(Window.Name))
        //    {
        //        throw new Exception("Name can't be empty");
        //    }
        //}

        public void NavigateToDetails(Window selectedWindow)
        {

            NavigationManager.NavigateTo($"/windowdetail/{selectedWindow.WindowId}");

        }
    }
}
