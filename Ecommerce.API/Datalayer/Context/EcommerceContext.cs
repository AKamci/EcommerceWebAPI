using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Datalayer.Context
{
    public class EcommerceContext(DbContextOptions<EcommerceContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            // Seeding

            //modelBuilder.Entity<Category>().HasData(Seed.Categories());
            //modelBuilder.Entity<User>().HasData(Seed.Users());
            //modelBuilder.Entity<Product>().HasData(Seed.Products());
            //modelBuilder.Entity<Order>().HasData(Seed.Orders());
            //modelBuilder.Entity<User>().HasData(Seed.ReadUserFromJsonFile());

            // Unique Field
            modelBuilder.Entity<User>().HasIndex(t => t.Email).IsUnique();

            // User Validations
            modelBuilder.Entity<User>().Property(t => t.MiddleName).HasMaxLength(9);
            modelBuilder.Entity<User>().Property(t => t.Name).HasMaxLength(9);
            modelBuilder.Entity<User>().Property(t =>t.Surname).HasMaxLength(9);

            modelBuilder.Entity<Product>().Ignore(t => t.Category);

            base.OnModelCreating(modelBuilder);
        }

        //Migration check
        public static bool CheckMigration(DbContext context)
        {
            var applied = context.Database.GetAppliedMigrations();
            return applied != null && applied.Any();
        }

        public override int SaveChanges()
        {
            ChangeTracker.Entries<Entity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList().ForEach(e =>
            {
                if (e.State == EntityState.Added)
                {
                    e.Entity.CreatedAt = DateTime.UtcNow;
                }
                if (e.State == EntityState.Modified)
                {
                    e.Entity.UpdatedAt = DateTime.UtcNow;
                }
            });

            return base.SaveChanges();
        }

    }
}