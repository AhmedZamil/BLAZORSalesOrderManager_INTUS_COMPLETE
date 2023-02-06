
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SalesOrderManager.App.BLL.Interfaces;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Pages
{
    public partial class OrderEdit
    {
        [Inject]
        public IOrderDataService? OrderDataService { get; set; }

        [Inject]
        public IStateDataService? StateDataService { get; set; }

        [Inject]
        public IWindowDataService? WindowDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }



        [Parameter]
        public string? OrderId { get; set; }

        public Order Order { get; set; } = new Order();

        public List<SalesOrderManager.Shared.Domain.State> States { get; set; } = new List<SalesOrderManager.Shared.Domain.State>();

        //public List<Window> SubElements { get; set; } = new List<SubElement>();
        //public List<SubElement> SelectedSubElements { get; set; } = new List<SubElement>();


        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        private IBrowserFile selectedFile;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            States = (await StateDataService.GetAllStates()).ToList();
            //SubElements = (await SubElementDataService.GetAllSubElements()).ToList();

            int.TryParse(OrderId, out var orderId);

            if (orderId == 0) //new employee is being created
            {
                //add some defaults
                Order = new Order {
                    Windows = new List<Window>(),
                    State = new SalesOrderManager.Shared.Domain.State()
                };

            }
            else
            {
                Order = await OrderDataService.GetOrderDetails(int.Parse(OrderId));
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

            if (Order.OrderId == 0) //new
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

                //Order.Windows.AddRange(SelectedSubElements);
                //SalesOrderManager.Shared.Domain.State _state = States.Find(s => s.StateId == Order.StateId);
                //Order.State = _state;

                var addedOrder = await OrderDataService.AddOrder(Order);
                if (addedOrder != null)
                {
                    StatusClass = "alert-success";
                    Message = "New Order added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new Order. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await OrderDataService.UpdateOrder(Order);
                StatusClass = "alert-success";
                Message = "Order updated successfully.";
                Saved = true;
            }
        }

        protected async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteOrder()
        {
            await OrderDataService.DeleteOrder(Order.OrderId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        //AddSubElements
        private async Task OnSelectionChanged(ChangeEventArgs eventArgs)
        {
            //SubElement element = SubElements.Find(e => e.SubElementId.ToString() == eventArgs.Value.ToString());

            //element.SubElementId = 0;
            //element.WindowId = Window.WindowId;
            //Window.SubElements.Add(element);
            //SelectedSubElements.Add(element);
            //SubElements.SelectedOptions = selection;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo($"/orderdetails/{OrderId}");
        }
    }
}
