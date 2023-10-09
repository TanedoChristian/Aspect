using AspectUI.Models;
using System.Text.Json;

namespace AspectUI.Services.UserService
{
    public class UserService : IUserService
    {
        private HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return JsonSerializer.Deserialize<IEnumerable<User>>(await _httpClient.GetStreamAsync($"api/user"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
