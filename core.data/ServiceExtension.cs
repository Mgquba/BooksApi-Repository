using core.data.Context;
using core.data.Repositories;
using core.data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.data
{
    public static class ServiceExtensionData
    {
        public static void AddDataAccessLayer(this IServiceCollection services, string connectString)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //configure PostgreSQL
            services.AddDbContext<BookServiceContext>(x =>
            {
                x.UseNpgsql(connectString,
                    y => y.MigrationsAssembly(typeof(BookServiceContext).Assembly.FullName));
            });
        }
    }
}
