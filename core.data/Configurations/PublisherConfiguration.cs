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
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasData(
                new Publisher
                {
                    Id = Guid.NewGuid(),
                    FullName = "Mike Best"
                },
                new Publisher
                {
                    Id = Guid.NewGuid(),
                    FullName = "Maria Rose"
                },
                new Publisher
                {
                    Id = Guid.NewGuid(),
                    FullName = "Chris John",
                    
                });
               
        }
    }
}
