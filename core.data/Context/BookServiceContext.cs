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
        DbSet<Publisher> Publishers { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Book_Author> Books_Authors { get; set; }
    }

    public class BookServiceContext : DbContext, IBookServiceContext, IUnitOfWork
    {
        public BookServiceContext(DbContextOptions<BookServiceContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Books_Authors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookServiceContext).Assembly);

            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Author)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Author>()
             .HasOne(b => b.Author)
             .WithMany(ba => ba.Book_Author)
             .HasForeignKey(bi => bi.AuthorId);

        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries<Book>())
            {

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateAdded = DateTime.UtcNow;
                }
            }

            await base.SaveChangesAsync(cancellationToken);
            return true;
        }

        public class BookServiceContextDesignFactory : IDesignTimeDbContextFactory<BookServiceContext>
        {
            public BookServiceContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                var builder = new DbContextOptionsBuilder<BookServiceContext>();
                var connectionString = configuration.GetConnectionString
                    ("BooksConnectionString");
                builder.UseNpgsql(connectionString);

                return new BookServiceContext(builder.Options);
            }
         
        }
    }


}
