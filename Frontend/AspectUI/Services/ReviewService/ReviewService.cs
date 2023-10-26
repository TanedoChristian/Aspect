using AspectUI.Models;
using System.Text;
using System.Text.Json;

namespace AspectUI.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        private HttpClient _client;

        public ReviewService(HttpClient client)
        {
            _client = client;
        }

        public async Task Create(ProductReview entity)
        {
            var content = new StringContent(
                   JsonSerializer.Serialize(entity),
                   Encoding.UTF8,
                   "application/json"
               );
            await _client.PostAsync("api/review", content);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductReview>> GetAll()
        {
            throw new NotImplementedException();
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
