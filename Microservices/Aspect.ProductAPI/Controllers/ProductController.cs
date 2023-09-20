using Aspect.ProductAPI.Repository.ProductRepository;
using Microsoft.AspNetCore.Mvc;

namespace Aspect.ProductAPI.Controllers
{
    public class ProductController : BaseApiController
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository) 
        { 
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepository.GetById(id);

            if(product == null)
            {
                return BadRequest();
            }

            return Ok(product);
        }

      
    }
}
