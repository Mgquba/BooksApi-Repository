using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace core.Handlers
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterDomainLayer(this IServiceCollection services, Assembly assembly)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            return services;
        }
    }
}
