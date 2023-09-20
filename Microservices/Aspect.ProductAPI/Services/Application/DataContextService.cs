using Aspect.ProductAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Aspect.ProductAPI.Services.Application
{
    public static class DataContextService
    {

        public static IServiceCollection AddDataContextService(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            });


            return services;
        }
    }
}
