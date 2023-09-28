using CartApi.Repository.CartRepository;

namespace CartApi.Services.Application
{
    public static class ScopedService
    {

        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {

            services.AddScoped<ICartRepository, CartRepository>();

            return services;

        }
    }
}
