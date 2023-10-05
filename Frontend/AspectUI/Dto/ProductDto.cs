using AspectUI.Models;

namespace AspectUI.Dto
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Category { get; set; } = "Clothing";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Gender { get; set; } = "Unisex";

        public override string ToString()
        {
            return $"{Name} - {Category}  - {Price} - {Quantity} - {Gender}";
        }
    }
}
