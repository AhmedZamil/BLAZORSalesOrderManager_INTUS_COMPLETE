using SalesOrderManager.App;
using SalesOrderManager.App.State;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SalesOrderManager.App.BLL.Interfaces;
using SalesOrderManager.App.BLL.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<IStateDataService, StateDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddHttpClient<IOrderDataService, OrderDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddHttpClient<IWindowDataService, WindowDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddHttpClient<ISubElementDataService, SubElementDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddHttpClient<IEmailService, EmailService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ApplicationState>();

await builder.Build().RunAsync();
