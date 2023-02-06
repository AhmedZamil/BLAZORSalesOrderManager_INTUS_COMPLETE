using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SalesOrderManager.BLL;
using SalesOrderManager.Shared.Domain;


namespace SalesOrderManager.App.Pages
{
    public partial class WindowEditNew
    {
        [Inject]
        public IWindowDataService? WindowDataService { get; set; }

        private ElementReference _selectReference;

        [Inject]
        public ISubElementDataService? SubElementDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }



        [Parameter]
        public string? WindowId { get; set; }

        public Window Window { get; set; } = new Window();

        private EditContext? editContext;

        public List<SubElement> SubElements { get; set; } = new List<SubElement>();
        public List<SubElement> SelectedSubElements { get; set; } = new List<SubElement>();


        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        private IBrowserFile selectedFile;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;


            SubElements = (await SubElementDataService.GetAllSubElements()).ToList();

            int.TryParse(WindowId, out var windowId);

            if (windowId == 0) //new employee is being created
            {
                //add some defaults
                Window = new Window { SubElements = new List<SubElement>() };

            }
            else
            {
                Window = await WindowDataService.GetWindowDetails(int.Parse(WindowId));
            }

            //editContext = new(Window);
        }

        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (Window.WindowId == 0) //new
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

                Window.SubElements.AddRange(SelectedSubElements);

                var addedWindow = await WindowDataService.AddWindow(Window);
                if (addedWindow != null)
                {
                    StatusClass = "alert-success";
                    Message = "New Window added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new Window. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await WindowDataService.UpdateWindow(Window);
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

        protected async Task DeleteWindow()
        {
            await WindowDataService.DeleteWindow(Window.WindowId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        //AddSubElements
        private async Task OnSelectionChanged(ChangeEventArgs eventArgs)
        {
            SubElement element = SubElements.Find(e => e.SubElementId.ToString() == eventArgs.Value.ToString());

            element.SubElementId = 0;
            element.WindowId = Window.WindowId;
            //Window.SubElements.Add(element);
            SelectedSubElements.Add(element);
            //SubElements.SelectedOptions = selection;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/windowoverview");
        }
    }
}
