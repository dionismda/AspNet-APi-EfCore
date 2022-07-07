using AspNet_Api_EfCore.Features.CategoryFeatures.Commands;
using AspNet_Api_EfCore.Features.CategoryFeatures.Queries;
using AspNet_Api_EfCore.Handlers;
using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.Models;
using AspNet_Api_EfCore.Repositories;
using AspNet_Api_EfCore.Repositories.Interfaces;
using AspNet_Api_EfCore.Services;
using AspNet_Api_EfCore.Services.Interfaces;
using AspNet_Api_EfCore.ViewModels;
using MediatR;
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

            services.AddScoped<IRequestHandler<GetAllCategoryQuery, IResultViewModel<IPagination<Category>>>, CategoryHandler>();
            services.AddScoped<IRequestHandler<GetCategoryQuery, IResultViewModel<Category>>, CategoryHandler>();
            services.AddScoped<IRequestHandler<CreateCategoryCommand, IResultViewModel<Category>>, CategoryHandler>();
            services.AddScoped<IRequestHandler<UpdateCategoryCommand, IResultViewModel<Category>>, CategoryHandler>();
            services.AddScoped<IRequestHandler<DeleteCategoryCommand, bool>, CategoryHandler>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }

        public static IServiceCollection AddCustomFormat(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            return services;
        }

    }
}