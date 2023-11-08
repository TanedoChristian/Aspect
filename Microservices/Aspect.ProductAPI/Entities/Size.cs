using System.ComponentModel.DataAnnotations;

namespace Aspect.ProductAPI.Entities
{
    public class Size
    {
        [Key]
        public int Id { get; set; }

        public int ProductId {  get; set; }
        public string ProductSize {get; set;}
        public int Quantity {get; set;}

    }
}
