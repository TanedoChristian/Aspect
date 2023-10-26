using AspectUI.Components;
using AspectUI.Models;
using AspectUI.Services.ProductService;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using System.Xml.Linq;
using CurrieTechnologies.Razor.SweetAlert2;
using AspectUI.Services.CartService;

namespace AspectUI.Pages
{
    public partial class ProductPage
    {
        [Parameter]
        public string Id { get; set; }
        public Product Product { get; set; }

        public string MainImage { get; set; }

        public int Quantity { get; set; } = 1;

        public List<string> SizeOptions = new List<string> { "XS", "S", "M", "L" };

        public string SelectedOption = "XS";

        [Inject]
        private SweetAlertService Swal { get; set; }

        [Inject]
        public IProductService _productService { get; set; }
        [Inject]
        public ICartService _cartService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadProduct(int.Parse(Id));
            await base.OnInitializedAsync();
        }



        private async Task LoadProduct(int id)
        {
            Product = await _productService.GetById(id);
            MainImage = Product.Photos[0].PhotoUrl;

        }

        private void ChangeMainImage(string photo)
        {

            MainImage = photo;
        }

        private void HandleQuantity(string action)
        {
            if(action == "increase")
            {
                Quantity++;
            } else
            {
                Quantity--;
            }
        }

        public void HandleSelectedSize(string option)
        {
            SelectedOption = option;
            Console.WriteLine(SelectedOption);
        }


        protected async Task AddToCart()
        {

            await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Product Added",
                Icon = SweetAlertIcon.Success,
            });




            var cart = new Cart()
            {
                ProductId = Product.Id,
                ProductName = Product.Name,
                Price = Product.Price,
                Quantity = Quantity,
                Size = SelectedOption,
                UserId = 1,
                ProductImage = Product.Photos[0].PhotoUrl
        };


            await _cartService.Create(cart);
        }


    }
}
