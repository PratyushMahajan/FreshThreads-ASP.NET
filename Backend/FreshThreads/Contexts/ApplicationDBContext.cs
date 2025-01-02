namespace FreshThreads.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using FreshThreads.Models;

    public class ApplicationDBContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        // Constructor that accepts DbContextOptions
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-Many: Shop -> Orders
            modelBuilder.Entity<Shop>()
                .HasMany(s => s.Orders) // Shop has many Orders
                .WithOne(o => o.Shop) // Each Order has one Shop
                .HasForeignKey(o => o.ShopId); // Foreign key in Orders

            // Many-to-One: Orders -> Users
            modelBuilder.Entity<Orders>()
                .HasOne(o => o.User)       // Each Order has one User
                .WithMany(u => u.Orders)    // One User has many Orders
                .HasForeignKey(o => o.UserId);  // Foreign key in Orders (UserId)

            // Many-to-One: Orders -> Delivery
            modelBuilder.Entity<Orders>()
                .HasOne(o => o.Delivery) // Each Order has one Delivery
                .WithMany(d => d.Orders) // A Delivery can have many Orders
                .HasForeignKey(o => o.DeliveryId); // Foreign key in Orders

            // One-to-Many: Delivery -> Orders (No need for reverse definition)
            modelBuilder.Entity<Delivery>()
                .HasMany(d => d.Orders) // Delivery has many Orders
                .WithOne(o => o.Delivery) // Each Order has one Delivery
                .HasForeignKey(o => o.DeliveryId); // Foreign key in Orders

            // Many-to-One: Users -> Shop
            modelBuilder.Entity<Users>()
                .HasOne(u => u.Shop) // Each User belongs to one Shop
                .WithMany(s => s.Users) // A Shop can have many Users
                .HasForeignKey(u => u.ShopId); // Foreign key in Users
        }
    }
}
