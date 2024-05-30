using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal sealed class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Name).HasMaxLength(100);

            builder.Property(item => item.Description).HasMaxLength(1000);

            builder.Property(item => item.Category).HasMaxLength(100);

            builder.Property(item => item.Url).HasMaxLength(1000);
        }
    }
}
