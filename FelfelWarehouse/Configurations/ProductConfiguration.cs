using FelfelWarehouse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FelfelWarehouse.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Map entities to tables  
            builder.ToTable("products");

            // Configure Primary Keys  
            builder.HasKey(e => e.Id).HasName("PK_Products");

            builder.Property(e => e.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            builder.Property(e => e.Name).HasColumnType("nvarchar(50)");
            builder.Property(e => e.CreatedAt).HasColumnType("datetime").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.UpdatedAt).HasColumnType("datetime").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
