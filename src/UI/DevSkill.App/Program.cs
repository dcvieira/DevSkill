using Blazored.LocalStorage;
using DevSkill.App;
using DevSkill.App.Auth;
using DevSkill.App.Contracts;
using DevSkill.App.Services;
using DevSkill.App.Services.Base;
using DevSkill.App.Services.Base.Catalog;
using DevSkill.App.Services.Base.Order;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


//builder.Services.AddSingleton(new HttpClient
//{
//    BaseAddress = new Uri("https://localhost:7020")
//});

builder.Services.AddTransient<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient<ICatalogClient, CatalogClient>(client => client.BaseAddress = new Uri("https://localhost:7020"))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IOrderClient, OrderClient>(client => client.BaseAddress = new Uri("https://localhost:7270"))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
builder.Services.AddScoped<ICourseDataService, CourseDataService>();
builder.Services.AddScoped<IOrderDataService, OrderDataService>();
builder.Services.AddScoped<ICheckoutDataService, CheckoutDataService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

await builder.Build().RunAsync();
