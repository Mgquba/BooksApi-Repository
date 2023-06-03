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
    public class AuthorConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Author
                {
                    Id = Guid.NewGuid(),
                    FullName = "John Doe"

                },
                new Author
                {
                    Id = Guid.NewGuid(),
                    FullName = "Jane Doe"

                },
                 new Author
                 {
                     Id = Guid.NewGuid(),
                     FullName = "Bob Mate"

                 });
                 
        }
    }
}
