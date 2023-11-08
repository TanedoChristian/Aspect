using AspectUI.Models;
using System.Text;
using System.Text.Json;

namespace AspectUI.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client;
        }
        public async Task Create(UserPayment entity)
        {
            var content = new StringContent(
                     JsonSerializer.Serialize(entity),
                     Encoding.UTF8,
                     "application/json"
                 );
            await _client.PostAsync("api/order", content);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserPayment>> GetAll()
        {
			return JsonSerializer.Deserialize<IEnumerable<UserPayment>>(await _client.GetStreamAsync($"/api/order"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
		}

        public Task<UserPayment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserPayment entity)
        {
            throw new NotImplementedException();
        }
    }
}
