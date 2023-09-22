using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Repositories.UserRepository;

namespace UserApi.Services.Application
{
    public static class ApplicationService
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddDataContextServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }

    }
}
