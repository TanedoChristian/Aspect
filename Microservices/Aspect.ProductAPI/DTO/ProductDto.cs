namespace Aspect.ProductAPI.DTO
{
    public class ProductDto
    {
      
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string Image { get; set; }
    }
}
