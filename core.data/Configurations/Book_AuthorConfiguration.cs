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
    public class Book_AuthorConfiguration : IEntityTypeConfiguration<Book_Author>
    {
        public void Configure(EntityTypeBuilder<Book_Author> builder)
        {
            builder.HasData(
             new Book_Author
                {
                    Id = Guid.NewGuid(),
                    BookId = Guid.NewGuid(),
                    AuthorId = Guid.NewGuid(),
                },
                new Book_Author
                {
                    Id = Guid.NewGuid(),
                    BookId = Guid.NewGuid(),
                    AuthorId = Guid.NewGuid(),
                });


                
            
        }
    }
}
