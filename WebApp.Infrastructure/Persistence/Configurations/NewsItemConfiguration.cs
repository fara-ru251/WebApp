using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Domain.Entities;

namespace WebApp.Infrastructure.Persistence.Configurations
{
    public class NewsItemConfiguration : IEntityTypeConfiguration<NewsItem>
    {
        public void Configure(EntityTypeBuilder<NewsItem> builder)
        {
            builder.ToTable("News");

            builder.Property(p => p.Title)
                   .HasMaxLength(1024)
                   .IsRequired();

            builder.Property(p => p.Text)
                   .IsRequired();

            builder.Property(p => p.Url)
                   .HasMaxLength(256) 
                   .IsRequired();

            
        }
    }
}
