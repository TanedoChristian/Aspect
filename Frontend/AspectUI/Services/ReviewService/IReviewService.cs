using AspectUI.Models;

namespace AspectUI.Services.ReviewService
{
    public interface IReviewService : IBaseService<ProductReview>
    {
        Task<IEnumerable<ProductReview>> GetAllByProduct(int id);
    }
}
