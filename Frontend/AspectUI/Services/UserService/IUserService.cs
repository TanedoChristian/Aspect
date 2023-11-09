using AspectUI.Models;

namespace AspectUI.Services.UserService
{
    public interface IUserService : IBaseService<User>
    {

        Task<User> Login(string email, string password);
        Task<User> GetByEmail(string email);
    }
}
