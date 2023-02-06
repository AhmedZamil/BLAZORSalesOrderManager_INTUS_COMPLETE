using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SalesOrderManager.BLL;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Pages
{
    public partial class SubElementEdit
    {
        [Inject]
        public ISubElementDataService? SubElementDataService { get; set; }

        [Inject]
        public IWindowDataService? WindowDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }



        [Parameter]
        public string? SubElementId { get; set; }

        [Parameter]
        public string? WindowId { get; set; }

        public SubElement SubElement { get; set; } = new SubElement();

        public Window Window { get; set; } = new Window();


        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        private IBrowserFile selectedFile;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            int.TryParse(SubElementId, out var subElementId);
            int.TryParse(WindowId, out var windowId);

            if (subElementId == 0) //new employee is being created
            {
                if (windowId != 0)
                {
                    Window = await WindowDataService.GetWindowDetails(windowId);
                    SubElement = new SubElement { ElementType = ElementType.Doors.ToString() , WindowId = Window.WindowId };
                }
                else
                {
                    SubElement = new SubElement { ElementType = ElementType.Doors.ToString() };
                }
                //add some defaults
                
            }
            else
            {
                SubElement = await SubElementDataService.GetSubElementDetails(int.Parse(SubElementId));
            }
        }

        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (SubElement.SubElementId == 0) //new
            {
                //image adding
                if (selectedFile != null)//take first image
                {
                    var file = selectedFile;
                    Stream stream = file.OpenReadStream();
                    MemoryStream ms = new();
                    await stream.CopyToAsync(ms);
                    stream.Close();

                    //Employee.ImageName = file.Name;
                    //Employee.ImageContent = ms.ToArray();
                }

                var addedSubElement = await SubElementDataService.AddSubElement(SubElement);
                if (addedSubElement != null)
                {
                    StatusClass = "alert-success";
                    Message = "New Sub Element added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new Sub Element. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await SubElementDataService.UpdateSubElement(SubElement);
                StatusClass = "alert-success";
                Message = "Sub Element updated successfully.";
                Saved = true;
            }
        }

        protected async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteSubElement()
        {
            await SubElementDataService.DeleteSubElement(SubElement.SubElementId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/subelementoverview");
        }
    }
}
