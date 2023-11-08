using AspectUI.Models;
using AspectUI.Services.ReviewService;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Components
{
    public partial class Review
    {
        [Parameter]
        public Product Product { get; set; }


        public bool ShowReviewModal = false;

        public IEnumerable<ProductReview> Reviews { get; set; }

        [Inject]
        IReviewService _reviewService {  get; set; }

    protected override async Task OnInitializedAsync()
        {

            await LoadReviewAsync();
            await base.OnInitializedAsync();
        }


        public async Task LoadReviewAsync()
        {
            Reviews = await _reviewService.GetAllByProduct(Product.Id);
        }

        public void ToggleReviewModal()
        {
            ShowReviewModal = !ShowReviewModal;
        }
    }
}
