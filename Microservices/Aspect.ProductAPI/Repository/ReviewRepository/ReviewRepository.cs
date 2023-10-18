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

        public async Task Delete(ProductReview entity)
        {
            _context.ProductReviews.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<ProductReview>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductReview>> GetAllProductReview(int productId)
        {
            return await _context.ProductReviews.Where(product => product.ProductId == productId).ToListAsync();
        }

        public async Task<ProductReview> GetById(int id)
        {
            return await _context.ProductReviews.FirstOrDefaultAsync(product => product.Id == id);
        }

        public Task Update(ProductReview entity)
        {
            throw new NotImplementedException();
        }
    }
}
