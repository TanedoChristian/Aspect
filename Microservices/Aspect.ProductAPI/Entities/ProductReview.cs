using System.ComponentModel.DataAnnotations;

namespace Aspect.ProductAPI.Entities
{
    public class ProductReview
    {
        [Key]
        public int Id { get; set; }

        public int ProductId {  get; set; }
        public string CustomerName { get; set; }

        public string ReviewTitle {  get; set; }
        public string Review { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
       
    }
}
