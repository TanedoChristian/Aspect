using AspectUI.Models;
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
        ILocalStorageService LocalStorageService { get; set; }

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

        public List<int> Cart { get; set; } = new List<int>();

        protected override async Task OnInitializedAsync()
        {
            string json = await LocalStorageService.GetItemAsync<string>("cart");

            if (!string.IsNullOrEmpty(json))
            {
                Cart = JsonSerializer.Deserialize<List<int>>(json);
            }

            await base.OnInitializedAsync();
        }

        protected async Task AddToCart()
        {
            Cart.Add(Id);

            string json = JsonSerializer.Serialize(Cart);
            await LocalStorageService.SetItemAsync("cart", json);
        }
    }
}
