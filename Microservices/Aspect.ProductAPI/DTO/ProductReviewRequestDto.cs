namespace Aspect.ProductAPI.DTO
{
    public class ProductReviewRequestDto
    {
        public int ProductId { get; set; }
        public string CustomerName { get; set; }

        public string ReviewTitle { get; set; }
        public string Review { get; set; }
    }
}
