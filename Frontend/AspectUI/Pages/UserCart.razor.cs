using AspectUI.Models;
using AspectUI.Services.CartService;
using AspectUI.Services.OrderService;
using AspectUI.Services.UserService;
using Blazored.LocalStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Pages
{
    public partial class UserCart
    {
        [Inject]
        private ICartService _cartService { get; set; }

        [Inject]

        private SweetAlertService Swal { get; set; } 

        public IEnumerable<Cart> Carts { get; set; }

        public Cart Cart { get; set; }
        public static decimal SubTotal {get; set;}

        public string SelectedSize { get; set; }

        [Inject]
        ILocalStorageService localStorageService { get; set; }

        [Inject]
        IUserService userService { get; set; }

        
        
        public User User { get; set; }

        [Inject]
        IOrderService orderService  {get; set; }

        public UserPayment UserPayment { get; set; } = new UserPayment();



        private async Task LoadCartAsync()
        {

            int userid = await localStorageService.GetItemAsync<int>("userid");
            Carts = await _cartService.GetPendingByUser(userid);
            Carts = Carts.OrderBy(cart => cart.ProductName).ToList();
            SubTotal = Carts.Sum(cart => cart.Price * cart.Quantity);
        }
        protected override async Task OnInitializedAsync()
        {
            int id = await localStorageService.GetItemAsync<int>("userid");
            User = await userService.GetById(id);;
            await LoadCartAsync();
            await base.OnInitializedAsync();
        }

        private async Task DeleteCart(int id)
        {
            await _cartService.Delete(id);
            await LoadCartAsync();
        }


        private void HandleSelectedSize(ChangeEventArgs e)
        {
            Console.WriteLine(e.Value.ToString());
        }

        private async Task DecrementQuantity(Cart cart)
        {
            cart.UserId =  await localStorageService.GetItemAsync<int>("userid"); ;
            cart.Quantity--;


            if (cart.Quantity == 0)
            {
                await _cartService.Delete(cart.Id);
            }


            await _cartService.Update(cart);
            await LoadCartAsync();
        }

        private async Task IncrementQuantity(Cart cart)
        {
            cart.UserId =  await localStorageService.GetItemAsync<int>("userid"); ;
            cart.Quantity++;
            await _cartService.Update(cart);
            await LoadCartAsync();
        }

        public async Task CheckOut()
        {
            foreach(var cart in Carts)
            {
                cart.Status = "process";
                await _cartService.Update(cart);
            }
            UserPayment.Email = User.Email;
            UserPayment.UserId = User.Id;
            UserPayment.Cart = Carts;
            UserPayment.FirstName = User.FirstName;
            UserPayment.LastName = User.LastName;
            UserPayment.TotalAmount = SubTotal + 99;

            await orderService.Create(UserPayment); 

            await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Success",
                Icon = SweetAlertIcon.Success,
            });


        }

    }

}
