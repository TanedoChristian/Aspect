using AspectUI.Models;
using System.Text;
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

        public async Task Create(User entity)
        {
            var content = new StringContent(
                    JsonSerializer.Serialize(entity),
                    Encoding.UTF8,
                    "application/json"
                );
            await _httpClient.PostAsync("api/user", content);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return JsonSerializer.Deserialize<IEnumerable<User>>(await _httpClient.GetStreamAsync($"api/user"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<User> GetById(int id)
        {
            return JsonSerializer.Deserialize<User>(await _httpClient.GetStreamAsync($"api/user/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<User> Login(string email, string password)
        {
            var data = new { Email = email, Password = password };
            var content = new StringContent(
                JsonSerializer.Serialize(data),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await _httpClient.PostAsync("api/user/login", content);

            if (response.IsSuccessStatusCode)
            {

                var responseContent = await response.Content.ReadAsStringAsync();
                var user =  JsonSerializer.Deserialize<User>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return user;
            }
            else
            {

                return null;
            }
        }

            public Task Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
