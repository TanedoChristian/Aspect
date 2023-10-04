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

        public async Task Delete(int id)
        {
            await _client.DeleteAsync($"api/cart/delete/all/{id}");
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

            var content = new StringContent(
                   JsonSerializer.Serialize(entity),
                   Encoding.UTF8,
                   "application/json"
               );
            await _client.PutAsync($"api/cart/{entity.Id}", content);

        }
    }
}
