using AspectUI.Models;
using Microsoft.AspNetCore.Components;

namespace AspectUI.Components
{
    public partial class Review
    {
        [Parameter]
        public Product Product { get; set; }


        public bool ShowReviewModal = false;


        public void ToggleReviewModal()
        {
            ShowReviewModal = !ShowReviewModal;
        }
    }
}
