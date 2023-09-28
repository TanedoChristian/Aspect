using System.ComponentModel.DataAnnotations;

namespace CartApi.Entities
{
    public class Cart
    {

        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int UserId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
