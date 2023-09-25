using System.ComponentModel.DataAnnotations.Schema;

namespace Aspect.ProductAPI.Entities
{
    [Table("Photos")]
    public class ProductPhoto
    {
        public int Id { get; set; }
        public string PhotoUrl {  get; set; }


 
         public int ProductId { get; set; }
        public Product Product { get; set; }



    }
}
