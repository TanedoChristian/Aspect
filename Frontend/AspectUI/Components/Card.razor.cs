using AspectUI.Models;
using AspectUI.Services.CartService;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
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
        [Parameter]
        public string Category { get; set; }
        [Parameter]
        public decimal Price { get; set; }
        [Parameter]
        public int Quantity { get; set; }
        [Parameter]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Parameter]
        public List<ProductPhoto> Photos { get; set; } = new();


        public Cart Cart { get; set; }

        protected override async Task OnInitializedAsync()
        {
            
            await base.OnInitializedAsync();
        }

        protected async Task AddToCart()
        {

            var cart = new Cart()
            {
                ProductId = Id,
                ProductName = Name,
                Price = Price,
                Quantity = 1,
                UserId = 1
            };


            await _cartService.Create(cart);
        }
    }
}
