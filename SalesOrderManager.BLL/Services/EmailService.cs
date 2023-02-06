

using Blazored.LocalStorage;

namespace SalesOrderManager.App.Services
{
    public class EmailService : IEmailService
    {
        private readonly HttpClient? _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public EmailService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }
        public void SendEmail()
        {
            // Todo: Send emails
        }
    }
}
