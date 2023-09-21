namespace Aspect.ProductAPI.Entities
{
    public class ProductPhoto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string PhotoUrl {  get; set; }
        public Product Product { get; set; }
    }
}
