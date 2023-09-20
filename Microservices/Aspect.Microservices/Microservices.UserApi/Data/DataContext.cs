using Microservices.UserApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservices.UserApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
