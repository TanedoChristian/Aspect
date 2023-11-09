using AspectUI.Models;
using AspectUI.Services.CartService;
using AspectUI.Services.UserService;
using Blazored.LocalStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Pages.admin
{
    public partial class OrderAdmin
    {


        [Inject]
        ICartService cartService { get; set; }

        [Inject]
        SweetAlertService Swal {  get; set; }

        [Inject]
        ILocalStorageService localStorageService { get; set; }
        IEnumerable<Cart> Carts { get; set; }

        public Cart Cart { get; set; }

        public string Status {  get; set; }

        [Inject]
        IUserService userService {  get; set; }


        public User User {  get; set; }


        public string Category {  get; set; }

        IEnumerable<Cart> FilteredCarts { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await LoadCarts();
            await base.OnInitializedAsync();
        }

        public async Task LoadCarts()
        {
            Carts = await cartService.GetAll();
            FilteredCarts = Carts;
        }


        public async Task HandleCategory(ChangeEventArgs e)
        {
            Category = e.Value.ToString();

            if(Category == "all")
            {
                FilteredCarts = Carts;
            } else
            {
                FilteredCarts = Carts.Where(c => c.Status == Category).ToList();

            }

            
        }

        private void HandleSelectedSize(ChangeEventArgs e)
        {
            Status = e.Value.ToString();
        }

        public async Task SaveUpdate(Cart cart)
        {
            cart.Status = Status;
            await cartService.Update(cart);

            await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Updated",
                Icon = SweetAlertIcon.Success,
            });


      

        }


    }
}
