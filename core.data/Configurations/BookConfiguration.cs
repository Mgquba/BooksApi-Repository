using core.data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Rich Dad Poor Dad",
                    Description = "Story of a rich and poor dad",
                    IsRead= true,
                    DateRead = DateTime.UtcNow,
                    Rate = 5,
                    Genre = "Non-Fiction",
                    AuthorName = "JohnDoe",
                    CoverUrl = "RichDadPoorDad.png",
                    DateAdded = DateTime.UtcNow,
                    PublisherId = Guid.NewGuid(),

                });
        }
    }
}
