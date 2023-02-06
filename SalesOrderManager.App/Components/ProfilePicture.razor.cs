using Microsoft.AspNetCore.Components;

namespace SalesOrderManager.App.Components
{
    public partial class ProfilePicture
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
