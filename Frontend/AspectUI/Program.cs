using AspectUI;
using AspectUI.Services.CartService;
using AspectUI.Services.OrderService;
using AspectUI.Services.ProductService;
using AspectUI.Services.ReviewService;
using AspectUI.Services.UserService;
using Blazored.LocalStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Http;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);




builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddHttpClient<IUserService, UserService>(client => client.BaseAddress = new Uri("http://localhost:5108/"));
builder.Services.AddHttpClient<IOrderService, OrderService>(client => client.BaseAddress = new Uri("http://localhost:3001/"));
builder.Services.AddHttpClient<IProductService, ProductService>(client => client.BaseAddress = new Uri("http://localhost:5140/"));
builder.Services.AddHttpClient<ICartService, CartService>(client => client.BaseAddress = new Uri("http://localhost:5110/"));
builder.Services.AddHttpClient<IReviewService, ReviewService>(client => client.BaseAddress = new Uri("http://localhost:5140/"));





builder.Services.AddSweetAlert2();


await builder.Build().RunAsync();
