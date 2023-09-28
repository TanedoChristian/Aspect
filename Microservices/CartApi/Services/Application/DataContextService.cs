using CartApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CartApi.Services.Application
{
    public static class DataContextService
    {
        public static IServiceCollection AddDataContextServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
