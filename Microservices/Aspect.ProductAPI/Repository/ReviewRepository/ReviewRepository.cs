using Aspect.ProductAPI.Data;
using Aspect.ProductAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aspect.ProductAPI.Repository.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    {
        private DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;    
        }

        public async Task Create(ProductReview entity)
        {
            await _context.ProductReviews.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task Delete(ProductReview entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductReview>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductReview>> GetAllProductReview(int productId)
        {
            return await _context.ProductReviews.Where(product => product.ProductId == productId).ToListAsync();
        }

        public Task<ProductReview> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductReview entity)
        {
            throw new NotImplementedException();
        }
    }
}
