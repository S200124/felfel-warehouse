using FelfelWarehouse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FelfelWarehouse.Configurations
{
    public class MovementConfiguration : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            // Map entities to tables  
            builder.ToTable("movements");

            // Configure Primary Keys  
            builder.HasKey(e => e.Id).HasName("PK_Movements");

            builder.Property(e => e.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            builder.Property(e => e.BatchId).HasColumnType("int");
            builder.Property(e => e.Amount).HasColumnType("int");
            builder.Property(e => e.Timestamp).HasColumnType("datetime");
            builder.Property(e => e.Reason).HasColumnType("text");
            builder.Property(e => e.CreatedAt).HasColumnType("datetime").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(e => e.UpdatedAt).HasColumnType("datetime").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne<Batch>().WithMany().HasPrincipalKey(e => e.Id).HasForeignKey(e => e.BatchId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Movements_Batches");
        }
    }
}
