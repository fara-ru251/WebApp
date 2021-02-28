using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Domain.Entities;

namespace WebApp.Infrastructure.Persistence.Configurations
{
    class FrequentWordConfiguration : IEntityTypeConfiguration<FrequentWord>
    {
        public void Configure(EntityTypeBuilder<FrequentWord> builder)
        {
            builder.ToTable("FrequentWords");

            builder.Property(p => p.Name)
                   .HasMaxLength(256)
                   .IsRequired();
        }
    }
}
