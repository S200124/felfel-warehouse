using FelfelWarehouse.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FelfelWarehouse.Models
{
    public class MyDBContext : DbContext
    {
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new BatchConfiguration());
            modelBuilder.ApplyConfiguration(new MovementConfiguration());
        }
    }
}
