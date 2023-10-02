using AspectUI;
using AspectUI.Services.CartService;
using AspectUI.Services.ProductService;
using AspectUI.Services.UserService;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddHttpClient<IProductService, ProductService>(client => client.BaseAddress = new Uri("http://localhost:5140/"));
builder.Services.AddHttpClient<ICartService, CartService>(client => client.BaseAddress = new Uri("http://localhost:5110/"));



await builder.Build().RunAsync();
