using AspectUI.Models;
using AspectUI.Services.CartService;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Pages
{
    public partial class Ship
    {

        [Inject]
        ICartService cartService { get; set; }

        [Inject]
        ILocalStorageService localStorageService { get; set; }
        IEnumerable<Cart> Carts { get; set; }


        protected override async Task OnInitializedAsync()
        {

            await LoadCarts();
            await base.OnInitializedAsync();
        }

        public async Task LoadCarts()
        {
            int userid = await localStorageService.GetItemAsync<int>("userid");
            Carts = await cartService.GetAllByUser(userid);
            Carts = Carts.Where(c => c.Status.ToLower() == "approved").ToList();
        }
    }
}
