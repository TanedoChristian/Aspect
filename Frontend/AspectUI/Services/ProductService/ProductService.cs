using AspectUI.Models;
using System.Net.Http;
using System.Text.Json;

namespace AspectUI.Services.ProductService
{
    public class ProductService : IProductService
    {
        private HttpClient _httpClient;

        public ProductService(HttpClient client)
        {
            _httpClient = client;
        }

        public Task Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return JsonSerializer.Deserialize<IEnumerable<Product>>(await _httpClient.GetStreamAsync($"api/product"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public Task<Product> GetById()
        {
            throw new NotImplementedException();
        }

        public Task Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
