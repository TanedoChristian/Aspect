using Aspect.ProductAPI.DTO;
using Aspect.ProductAPI.Entities;
using Aspect.ProductAPI.Repository.ReviewRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Aspect.ProductAPI.Controllers
{
    public class ReviewController : BaseApiController
    {
        private IMapper _mapper;
        private IReviewRepository _reviewRepository;

        public ReviewController(IMapper mapper, IReviewRepository reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddReview(ProductReviewRequestDto productReviewDto)
        {
            var review = _mapper.Map<ProductReview>(productReviewDto);

            await _reviewRepository.Create(review);

            return Ok(review);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllProductReview(int id)
        {
            var reviews = await _reviewRepository.GetAllProductReview(id);

            if(reviews == null)
            {
                return NotFound("No Review");
            }

            return Ok(reviews);
        
        }
    }
}
