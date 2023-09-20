using Aspect.ProductAPI.Repository.ProductRepository;

namespace Aspect.ProductAPI.Services.Application
{
    public static class ScopedService
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
