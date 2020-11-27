using Microsoft.Extensions.DependencyInjection;
using Stefanini.Domain.Interfaces.Application;
using Stefanini.Domain.Interfaces.Service;
using Stefanini.Business.Services;
using Stefanini.Domain.Interfaces.Repository;
using Stefanini.Data.Repositories;
using Stefanini.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Stefanini.Application.Apps;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

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

            //services.AddDbContext<DataContext>(options => options.UseSqlServer(new SqlConnection("")));
            services.AddDbContext<DataContext>();

        }
    }
}
