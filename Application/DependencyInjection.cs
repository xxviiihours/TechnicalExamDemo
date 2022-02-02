using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace DEMO.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddValidatorsFromAssembly(Assembly.GetCallingAssembly());
            services.AddMediatR(Assembly.GetCallingAssembly());
            return services;
        }
    }
}
