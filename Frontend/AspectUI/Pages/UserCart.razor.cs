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

        protected override async Task OnInitializedAsync()
        {

            Carts = await _cartService.GetAllByUser(1);


            foreach(var cart in Carts)
            {
                SubTotal += (cart.Price * cart.Quantity);
            }
            

            await base.OnInitializedAsync();
        }
    }
}
