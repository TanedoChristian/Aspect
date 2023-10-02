using AspectUI.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace AspectUI.Services.CartService
{
    public class CartService : ICartService
    {
        private HttpClient _client;

        public CartService(HttpClient client)
        {
            _client = client;
        }

        public async Task Create(Cart entity)
        {

            var content = new StringContent(
                    JsonSerializer.Serialize(entity),
                    Encoding.UTF8,
                    "application/json"
                );
            await _client.PostAsync("api/cart", content);
        }

        public Task Delete(Cart entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cart>> GetAllByUser(int id)
        {
            return JsonSerializer.Deserialize<IEnumerable<Cart>>(await _client.GetStreamAsync($"api/cart/user/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Task<IEnumerable<Cart>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetById()
        {
            throw new NotImplementedException();
        }

        public async Task Update(Cart entity)
        {

            throw new NotImplementedException();
        }
    }
}
