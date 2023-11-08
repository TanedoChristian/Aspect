using CartApi.Data;
using CartApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CartApi.Repository.CartRepository
{
    public class CartRepository : ICartRepository
    {
        private DataContext _context;

        public CartRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(Cart entity)
        {
            await _context.Carts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Cart entity)
        {
            _context.Carts.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task<Cart> GetById(int id)
        {
            return await _context.Carts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cart>> GetByUserId(int id)
        {
            return await _context.Carts.Where(c => c.UserId == id).ToListAsync();
        }

        public async Task<IEnumerable<Cart>> GetPendingByUserId(int id)
        {
            return await _context.Carts.Where(c => c.UserId == id &&  c.Status == "pending").ToListAsync();
        }

        public async Task Update(Cart entity)
        {
            _context.Carts.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
