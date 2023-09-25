using Aspect.ProductAPI.Controllers;
using Aspect.ProductAPI.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Aspect.ProductAPI.Data
{
   public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductPhoto> ProductPhotos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Define the relationship between Product and ProductPhoto
        builder.Entity<ProductPhoto>()
            .HasOne(pp => pp.Product)        // ProductPhoto has one Product
            .WithMany(p => p.Photos)         // Product has many Photos
            .HasForeignKey(pp => pp.ProductId);  // Use ProductId as the foreign key
    }
}


  
}
