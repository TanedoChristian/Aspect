using Aspect.ProductAPI.DTO;
using Aspect.ProductAPI.Entities;
using Aspect.ProductAPI.Repository.ProductRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Aspect.ProductAPI.Controllers
{
    public class ProductController : BaseApiController
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper) 
        { 
            _productRepository = productRepository;
            _mapper = mapper;
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

        [HttpPost]
        public async Task <IActionResult> AddProduct(IEnumerable<ProductDto> productDto)
        {
            foreach(var p in productDto)
            {
                var product = _mapper.Map<Product>(p);

                await _productRepository.Create(product);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetById(id);

            if (product == null)
            {
                return BadRequest();
            }
            await _productRepository.Delete(product);
            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            var product = await _productRepository.GetById(id);
            _mapper.Map(productDto, product);

            await _productRepository.Update(product);
            return Ok(product);
        }
      
    }
}
