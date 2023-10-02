namespace AspectUI.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }

        public string ProductImage { get; set;  }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
