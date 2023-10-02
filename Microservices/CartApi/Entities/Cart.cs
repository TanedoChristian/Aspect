using System.ComponentModel.DataAnnotations;

namespace CartApi.Entities
{
    public class Cart
    {

        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImage {get; set;}
        public int UserId { get; set; }

        public int Quantity { get; set; }
        public decimal TotalPrice => Price * Quantity;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
