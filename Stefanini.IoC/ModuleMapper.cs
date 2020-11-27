using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Stefanini.IoC
{
    public static class ModuleMapper
    {
        public static IServiceCollection MapModulesContabil(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies(), ServiceLifetime.Scoped);
            return services;
        }
    }
}
