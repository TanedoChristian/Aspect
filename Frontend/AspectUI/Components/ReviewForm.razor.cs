using AspectUI.Models;
using AspectUI.Services.ReviewService;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Components
{
    public partial class ReviewForm
    {

        [Inject]

        IReviewService _reviewService {  get; set; }

        [Parameter]
        public Product Product { get; set; }

        private List<bool> starValues;


        [Parameter]
        public bool ShowReviewModal {  get; set; }


        public ProductReview ProductReview { get; set; } = new ProductReview();

        protected override void OnInitialized()
        {
            starValues = new List<bool> { false, false, false, false, false };
        }

        private void StarFilled(string num)
        {
            Console.WriteLine(num);
        }


        private async Task SendReview()
        {
            ProductReview.ProductId = 86;
            ProductReview.CustomerName = "test";
            ProductReview.ReviewTitle = "Test";

            await _reviewService.Create(ProductReview);

            HandleModal();
        }

        public void HandleModal()
        {
            ShowReviewModal = false;
        }
    }
}
