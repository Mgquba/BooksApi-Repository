using core.data.Context;
using core.data.Repositories;
using core.data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.data
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookServiceContext>(options =>
           options.UseNpgsql(configuration.GetConnectionString("BooksConnectionString"
           )

           ));


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

          return services;
        }
    }
}
