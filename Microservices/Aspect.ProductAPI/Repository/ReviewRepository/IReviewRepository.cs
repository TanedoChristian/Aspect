using Aspect.ProductAPI.Entities;

namespace Aspect.ProductAPI.Repository.ReviewRepository
{
    public interface IReviewRepository : IBaseRepository<ProductReview>
    {
        Task<IEnumerable<ProductReview>> GetAllProductReview(int productId);
    }
}
