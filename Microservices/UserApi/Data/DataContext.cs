using Microsoft.EntityFrameworkCore;
using UserApi.Entities;

namespace UserApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users {  get; set; }
        public DbSet<Address> Address {  get; set; }
    }
}
