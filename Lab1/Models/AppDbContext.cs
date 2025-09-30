using Microsoft.EntityFrameworkCore;

namespace Lab1.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AccountMember> AccountMembers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Mobile" },
                new Category { CategoryID = 2, CategoryName = "Laptop" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, ProductName = "Iphone 17 Pro Max", CategoryID = 1, UnitsInStock = 100, UnitPrice = 599 },
                new Product { ProductID = 2, ProductName = "Iphone 17 Pro", CategoryID = 1, UnitsInStock = 150, UnitPrice = 499 },
                new Product { ProductID = 3, ProductName = "Iphone 17 Air", CategoryID = 1, UnitsInStock = 200, UnitPrice = 399 },
                new Product { ProductID = 4, ProductName = "Macbook Air M4", CategoryID = 2, UnitsInStock = 200, UnitPrice = 1299 },
                new Product { ProductID = 5, ProductName = "Macbook Pro M4", CategoryID = 2, UnitsInStock = 200, UnitPrice = 1599 }

            );

            // Seed AccountMembers
            modelBuilder.Entity<AccountMember>().HasData(
                new AccountMember
                {
                    MemberID = "admin",
                    MemberPassword = "admin123",
                    FullName = "Administrator",
                    EmailAddress = "admin@example.com",
                    MemberRole = 1
                },
                new AccountMember
                {
                    MemberID = "user1",
                    MemberPassword = "user123",
                    FullName = "User One",
                    EmailAddress = "user1@example.com",
                    MemberRole = 0
                }
            );
        }
    }
}