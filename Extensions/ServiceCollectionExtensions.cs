using AspNet_Api_EfCore.Handlers;
using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.Models;
using AspNet_Api_EfCore.Repositories;
using AspNet_Api_EfCore.Repositories.Interfaces;
using AspNet_Api_EfCore.Services;
using Microsoft.AspNetCore.Identity;

namespace AspNet_Api_EfCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<CategoryHandler>();
            services.AddScoped<AccountHandler>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenServices, TokenServices>();
            return services;
        }

        public static IServiceCollection AddCustomFormat(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            return services;
        }

    }
}
