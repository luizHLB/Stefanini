using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Stefanini.Application.Apps;
using Stefanini.Business.Services;
using Stefanini.Data.Context;
using Stefanini.Data.Repositories;
using Stefanini.Domain.Interfaces.Application;
using Stefanini.Domain.Interfaces.Repository;
using Stefanini.Domain.Interfaces.Service;

namespace Stefanini.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterModules(this IServiceCollection services)
        {
            services.AddScoped<IUserApplication, UserApp>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICustomerApplication, CustomerApp>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<DataContext>();

        }
    }
}
