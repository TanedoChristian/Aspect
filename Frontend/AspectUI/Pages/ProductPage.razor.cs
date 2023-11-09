using AspectUI.Components;
using AspectUI.Models;
using AspectUI.Services.ProductService;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using System.Xml.Linq;
using CurrieTechnologies.Razor.SweetAlert2;
using AspectUI.Services.CartService;
using Blazored.LocalStorage;
using AspectUI.Services.ReviewService;

namespace AspectUI.Pages
{
    public partial class ProductPage
    {
        [Parameter]
        public string Id { get; set; }
        public Product Product { get; set; }

        public string MainImage { get; set; }

        [Inject]
        ILocalStorageService localStorageService { get; set; }

        public int Quantity { get; set; } = 1;

        public List<string> SizeOptions = new List<string> { "XS", "S", "M", "L" };

        public string SelectedOption = "XS";

        [Inject]
        private SweetAlertService Swal { get; set; }

        [Inject]
        public IProductService _productService { get; set; }
        [Inject]
        public ICartService _cartService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        IReviewService reviewService { get; set; }

        IEnumerable<ProductReview> ProductReviews { get; set; }
        


        public bool ShowReviewModal = false;



        protected override async Task OnInitializedAsync()
        {
            await LoadProduct(int.Parse(Id));
            await base.OnInitializedAsync();
        }



        private async Task LoadProduct(int id)
        {
            Product = await _productService.GetById(id);

            ProductReviews = await reviewService.GetAllByProduct(Product.Id);
            

            MainImage = Product.Photos[0].PhotoUrl;

        }

        private void ChangeMainImage(string photo)
        {

            MainImage = photo;
        }

        private async Task HandleQuantity(string action)
        {
            if(action == "increase")
            {
                if (Quantity == Product.Quantity)
                {
                    await Swal.FireAsync(new SweetAlertOptions()
                    {
                        Title = "Out of Stock",
                        Icon = SweetAlertIcon.Info

                    });

                    Quantity = Product.Quantity;
                } else
                {
                    Quantity++;
                }
            } else
            {
                if (Quantity == 0)
                {

                    await Swal.FireAsync(new SweetAlertOptions()
                    {
                        Title = "Invalid Amount",
                        Icon = SweetAlertIcon.Info

                    });

                    Quantity = 0;
                } else
                {
                    Quantity--;
                }

               
            }
        }

        public void HandleSelectedSize(string option)
        {
            SelectedOption = option;
            Console.WriteLine(SelectedOption);
        }


        protected async Task AddToCart()
        {

            string type = await localStorageService.GetItemAsync<string>("type");

            if (type == null)
            {
                NavigationManager.NavigateTo("/login");
            } else
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Product Added",
                    Icon = SweetAlertIcon.Success,
                });



                Product.Quantity = Product.Quantity - Quantity;
                Console.WriteLine(Product.Quantity);
                await _productService.Update(Product);



                var cart = new Cart()
                {
                    ProductId = Product.Id,
                    ProductName = Product.Name,
                    Price = Product.Price,
                    Quantity = Quantity,
                    Status = "pending",
                    Size = SelectedOption,
                    UserId = await localStorageService.GetItemAsync<int>("userid"),
                    ProductImage = Product.Photos[0].PhotoUrl
                };


                await _cartService.Create(cart);
            }
        }

           


    }
}
