using AspectUI.Models;
using System.Net.Http;
using System.Text;
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

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/product/{id}");
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return JsonSerializer.Deserialize<IEnumerable<Product>>(await _httpClient.GetStreamAsync($"api/product"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public async Task<Product> GetById(int id)
        {
            return JsonSerializer.Deserialize<Product>(await _httpClient.GetStreamAsync($"api/product/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public async Task Update(Product entity)
        {
			var content = new StringContent(
				   JsonSerializer.Serialize(entity),
				   Encoding.UTF8,
				   "application/json"
			   );
			await _httpClient.PutAsync($"api/product/{entity.Id}", content);
		}
    }
}
