using Microservices.UserApi.Data;
using Microservices.UserApi.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microservices.UserApi.Services
{
    public static class ApplicationService
    {
        
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {


           

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
