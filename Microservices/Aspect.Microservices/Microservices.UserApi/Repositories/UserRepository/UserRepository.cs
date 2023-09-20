using Microservices.UserApi.Data;
using Microservices.UserApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservices.UserApi.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }


        public async Task Add(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public Task<User> GetById(int id)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Update(User entity)
        {
             _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
