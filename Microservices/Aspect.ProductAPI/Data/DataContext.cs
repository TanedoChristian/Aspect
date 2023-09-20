using Aspect.ProductAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aspect.ProductAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
