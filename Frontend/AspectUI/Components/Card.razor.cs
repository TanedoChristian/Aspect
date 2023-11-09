using AspectUI.Models;
using AspectUI.Services.CartService;
using AspectUI.Services.ProductService;
using Blazored.LocalStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspectUI.Components
{
    public partial class Card
    {
        [Inject]
        private ICartService _cartService { get; set; }


        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public string Name { get; set; }


        [Inject]
        IProductService productService {  get; set; }

        public Product Product {  get; set; }

        [Parameter]
        public string Category { get; set; }
        [Parameter]
        public decimal Price { get; set; }
        [Parameter]
        public int Quantity { get; set; }

        [Inject]
        ILocalStorageService localStorageService { get; set; }
        [Parameter]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Parameter]
        public List<ProductPhoto> Photos { get; set; } = new();

        [Inject]
        NavigationManager NavigationManager { get; set; }


        public Cart Cart { get; set; }

        [Inject]
        private SweetAlertService Swal { get; set; }

        protected override async Task OnInitializedAsync()
        {
            
            await base.OnInitializedAsync();
        }


      

        protected async Task AddToCart()
        {

            string type = await localStorageService.GetItemAsync<string>("type");

            if(type == null)
            {
                NavigationManager.NavigateTo("/login");
            } else
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Product Added",
                    Icon = SweetAlertIcon.Success,
                });


                Product = await productService.GetById(Id);
                Product.Quantity--;

                await productService.Update(Product);

                var cart = new Cart()
                {
                    ProductId = Id,
                    ProductName = Name,
                    Price = Price,
                    Status = "pending",
                    Quantity = 1,
                    Size = "XS",
                    UserId = await localStorageService.GetItemAsync<int>("userid"),
                    ProductImage = Photos[0].PhotoUrl
                };


                await _cartService.Create(cart);
            }


         
        }
    }
}
