using AspectUI.Models;
using AspectUI.Services.CartService;
using AspectUI.Services.ProductService;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Pages
{
    public partial class Orders
    {

        [Inject]
        ICartService cartService {  get; set; }

        [Inject]
        ILocalStorageService localStorageService { get; set; }
        IEnumerable<Cart> Carts { get; set; }

        Product Product { get; set; }

        [Inject]
        IProductService productService { get; set; }


        protected override async Task OnInitializedAsync()
        {

            await LoadCarts();
            await base.OnInitializedAsync();
        }

        public async Task LoadCarts()
        {
            int userid = await localStorageService.GetItemAsync<int>("userid");
            Carts = await cartService.GetAllByUser(userid);
            Carts = Carts.Where(c => c.Status.ToLower() == "process").ToList();
        }

        public async Task CancelOrder()
        {
            foreach(var  cart in Carts)
            {
                cart.Status = "pending";


                Product = await productService.GetById(cart.Id);
                Product.Quantity = cart.Quantity;
                await productService.Update(Product);

                await cartService.Update(cart);
            }

            await LoadCarts();
        }



    }
}
