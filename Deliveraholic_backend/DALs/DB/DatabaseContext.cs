using deliveraholic_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace deliveraholic_backend.DALs
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


        // Set DB tables.

        public DbSet<Account> accounts { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<PackageDetails> packageDetails { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<PickupDeliveryDetails> pickupDeliveryDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderDetails>().ToTable("OrderDetails");
            modelBuilder.Entity<PackageDetails>().ToTable("PackageDetails");
            modelBuilder.Entity<Payment>().ToTable("Payment");
            modelBuilder.Entity<PickupDeliveryDetails>().ToTable("PickupDeliveryDetails");
        }
    }
}