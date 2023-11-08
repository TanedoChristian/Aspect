using UserApi.Entities;

namespace UserApi.Repositories.UserRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
      Task<User> GetUserByEmail(string email);
    }
}
