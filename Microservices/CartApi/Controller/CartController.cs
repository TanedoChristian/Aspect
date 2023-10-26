using AutoMapper;
using CartApi.Dto;
using CartApi.Entities;
using CartApi.Repository.CartRepository;
using Microsoft.AspNetCore.Mvc;

namespace CartApi.Controller
{
    public class CartController : BaseApiController
    {
        private ICartRepository _cartRepository;
        private IMapper _mapper;

        public CartController(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCart()
        {
            return Ok(await _cartRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById(int id)
        {
            return Ok(await _cartRepository.GetById(id));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {

            var cart = await _cartRepository.GetById(id);
            if(cart.Quantity == 0)
            {
                await _cartRepository.Delete(cart);
                return Ok("Delete 1");
            }

            cart.Quantity-= 1;
            await _cartRepository.Update(cart);
            return Ok("Deleted ");
        }

        [HttpDelete("delete/all/{id}")]
        public async Task<IActionResult> DeleteAll(int id)
        {
            var cart = await _cartRepository.GetById(id);
            await _cartRepository.Delete(cart);

            return Ok("Deleted");
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetCartByUser(int id)
        {
            return Ok(await _cartRepository.GetByUserId(id));
        }


        [HttpPost]
        public async Task<IActionResult> AddCart(CartDto cartDto)
        {
            var cartToCompare = await _cartRepository.GetByUserId(cartDto.UserId);

            var existingCart = cartToCompare.FirstOrDefault(c => c.ProductId == cartDto.ProductId);

            if (existingCart != null)
            {
                
                existingCart.Quantity += 1;
                await _cartRepository.Update(existingCart);
                return Ok(existingCart);
            }
            else
            {
                var cart = _mapper.Map<Cart>(cartDto);
                await _cartRepository.Create(cart);

                return Ok(cart);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartQuantity(int id, CartDto cartDto)
        {
            var cart = await _cartRepository.GetById(id);

            _mapper.Map(cartDto, cart);

            await _cartRepository.Update(cart);
            return Ok(cart);
        }  
    }
}
