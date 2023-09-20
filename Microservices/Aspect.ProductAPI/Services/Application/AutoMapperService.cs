namespace Aspect.ProductAPI.Services.Application
{
    public static class AutoMapperService
    {

        public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
