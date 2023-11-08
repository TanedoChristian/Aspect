namespace AspectUI.Models
{
    public class ProductReview
    {

        public int ProductId { get; set; }

        public string CustomerName {  get; set; }
        public string ReviewTitle {  get; set; }

        public int ReviewStar { get; set; }
        public string Review {  get; set; }
    }
}
