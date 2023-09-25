using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspect.ProductAPI.DTO
{
    public class ProductResponseDto
    {
        public string Name {  get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity {  get; set; }
       

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<ProductDto> Photos { get; set; } = new();
    }
}