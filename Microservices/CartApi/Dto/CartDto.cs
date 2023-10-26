namespace CartApi.Dto
{
    public class CartDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Size {get; set;}
        public string ProductImage {get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}
