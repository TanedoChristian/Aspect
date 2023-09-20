using Aspect.ProductAPI.Data;
using Aspect.ProductAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aspect.ProductAPI.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private DataContext _context;

        public ProductRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task Create(Product entity)
        {
           await _context.Products.AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task Delete(Product entity)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id ==  id);
        }

        public async Task Update(Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
