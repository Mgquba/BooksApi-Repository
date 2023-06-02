using core.data.Entities;
using core.data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.data.Context
{
    public interface IBookServiceContext
    {
        DbSet<Book> Books { get; set; }
    }

    public class BookServiceContext : DbContext, IBookServiceContext, IUnitOfWork
    {
        public BookServiceContext(DbContextOptions<BookServiceContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken)
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }

        public class BookServiceContextDesignFactory : IDesignTimeDbContextFactory<BookServiceContext>
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false)
                   .Build();

            public BookServiceContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<BookServiceContext>()
                     .EnableSensitiveDataLogging()
                     .UseNpgsql(configuration.GetConnectionString("BooksConnectionString"));

                return new BookServiceContext(optionsBuilder.Options);
            }
        }
    }


}
