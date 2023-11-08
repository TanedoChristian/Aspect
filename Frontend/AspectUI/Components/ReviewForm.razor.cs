using AspectUI.Models;
using AspectUI.Services.CartService;
using AspectUI.Services.ReviewService;
using Blazored.LocalStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Components
{
    public partial class ReviewForm
    {

        [Inject]
        ICartService cartService { get; set; }

        Cart Cart {  get; set; }

        IEnumerable<Cart> Carts { get; set; }

        [Inject]

        IReviewService _reviewService {  get; set; }

        [Parameter]
        public Product Product { get; set; }

        private List<bool> starValues;


        [Inject]
        ILocalStorageService localStorageService { get; set; }

        [Inject]
        SweetAlertService Swal {  get; set; }


        [Parameter]
        public bool ShowReviewModal {  get; set; }


        public List<string> ReviewTitle = new List<string>() { 
            "Poor",
            "Bad",
            "Good",
            "Great",
            "Outstanding",
            "Perfect"
        };


        public ProductReview ProductReview { get; set; } = new ProductReview();

        private int selectedRating = 3;

        private void HandleRatingChange(int newValue)
        {
            selectedRating = newValue;
        }

        protected override void OnInitialized()
        {
           
        }
        private async Task SendReview()
        {
            ProductReview.ProductId = Product.Id;
            ProductReview.CustomerName = await localStorageService.GetItemAsync<string>("username");
            ProductReview.ReviewStar = selectedRating;
            ProductReview.ReviewTitle = ReviewTitle[selectedRating];
            await _reviewService.Create(ProductReview);

            await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Review Addedd",
                Icon = SweetAlertIcon.Success,
            });

            int userid = await localStorageService.GetItemAsync<int>("userid");

            Carts = await cartService.GetAllByUser(userid);

            Carts = Carts.Where(c => c.ProductId ==  Product.Id).ToList();

            foreach(var cart in Carts)
            {
                cart.Status = "reviewed";

                await cartService.Update(cart);
            }


            HandleModal();
        }

        public void HandleModal()
        {
            ShowReviewModal = false;
        }
    }
}
