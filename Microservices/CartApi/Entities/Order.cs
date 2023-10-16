using System.ComponentModel.DataAnnotations;

namespace CartApi.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int CartId { get; set; }

        public string Status { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
