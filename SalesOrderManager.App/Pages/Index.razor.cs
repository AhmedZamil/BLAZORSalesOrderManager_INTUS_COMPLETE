using Microsoft.AspNetCore.Components;
using SalesOrderManager.App.BLL.Interfaces;
using SalesOrderManager.App.Components.Widgets;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.App.Pages
{
    public partial class Index
    {
        public List<Type> Widgets { get; set; } = new List<Type>() { typeof(OrderCountWidget), typeof(InboxWidget)};

        public Concern NewConcern { get; set; } = new Concern();

        public bool EmailSent { get; set; } = false;

        [Inject]
        public IEmailService emailSerivce { get; set; }



        public void SubmitConcern()
        {
            emailSerivce.SendEmail();
            EmailSent = true;
        }

        public void ResetForm()
        {
            NewConcern = new Concern();
            EmailSent = false;
        }


    }
}
