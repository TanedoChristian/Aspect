using AspectUI.Models;
using AspectUI.Services.CartService;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Pages
{
    public partial class UserCart
    {
        [Inject]
        private ICartService _cartService { get; set; }

        public IEnumerable<Cart> Carts { get; set; }

        public static decimal SubTotal {get; set;}


        private async Task LoadCartAsync()
        {
            Carts = await _cartService.GetAllByUser(1);
            SubTotal = Carts.Sum(cart => cart.Price * cart.Quantity);
        }
        protected override async Task OnInitializedAsync()
        {


            await LoadCartAsync();

            await base.OnInitializedAsync();
        }

        private async Task DeleteCart(int id)
        {
            await _cartService.Delete(id);

            await LoadCartAsync();
            
        }
    }
}
