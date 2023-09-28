using CartApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CartApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Cart> Carts { get; set; }
    }
}
