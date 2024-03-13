using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Datalayer.Context
{
    public class EcommerceContext(DbContextOptions<EcommerceContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<IdCard> IdCards { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-many relationship
            //modelBuilder.Entity<Category>().HasMany<Product>().WithOne(t => t.Category);
            //modelBuilder.Entity<Cart>().HasMany<Product>();
            //modelBuilder.Entity<Cart>().HasMany<User>();
            //modelBuilder.Entity<Order>().HasMany<Product>();   
            


            // Unique Field
            modelBuilder.Entity<User>().HasIndex(t => t.Email).IsUnique();

            // User Validations
            modelBuilder.Entity<User>().Property(t => t.MiddleName).HasMaxLength(9);
            modelBuilder.Entity<User>().Property(t => t.Name).HasMaxLength(9);
            modelBuilder.Entity<User>().Property(t =>t.Surname).HasMaxLength(9);


            base.OnModelCreating(modelBuilder);
        }
    }
}
