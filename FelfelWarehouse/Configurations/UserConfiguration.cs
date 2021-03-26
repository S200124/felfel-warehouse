using FelfelWarehouse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FelfelWarehouse.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Map entities to tables  
            builder.ToTable("users");

            // Configure Primary Keys  
            builder.HasKey(e => e.Id).HasName("PK_Users");

            builder.Property(e => e.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            builder.Property(e => e.FirstName).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.LastName).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.UserGroupId).HasColumnType("int").IsRequired();
            builder.Property(e => e.CreationDateTime).HasColumnType("datetime").IsRequired();
            builder.Property(e => e.LastUpdateDateTime).HasColumnType("datetime").IsRequired();
        }
    }
}
