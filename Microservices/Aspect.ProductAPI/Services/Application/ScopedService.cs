using Aspect.ProductAPI.Repository.ProductRepository;
using Aspect.ProductAPI.Repository.ReviewRepository;

namespace Aspect.ProductAPI.Services.Application
{
    public static class ScopedService
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();

            return services;
        }
    }
}
