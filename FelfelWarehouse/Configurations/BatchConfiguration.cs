using FelfelWarehouse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FelfelWarehouse.Configurations
{
    public class BatchConfiguration : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            // Map entities to tables  
            builder.ToTable("batches");

            // Configure Primary Keys  
            builder.HasKey(e => e.Id).HasName("PK_Batches");

            builder.Property(e => e.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            builder.Property(e => e.ProductId).HasColumnType("int");
            builder.Property(e => e.Quantity).HasColumnType("int");
            builder.Property(e => e.ExpirationDate).HasColumnType("datetime");
            builder.Property(e => e.CreatedAt).HasColumnType("datetime").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.UpdatedAt).HasColumnType("datetime").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne<Product>().WithMany().HasPrincipalKey(e => e.Id).HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Batches_Products");
        }
    }
}
