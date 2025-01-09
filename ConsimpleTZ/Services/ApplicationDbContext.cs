using ConsimpleTZ.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTZ.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Customer)
                .WithMany(c => c.Purchases)
                .HasForeignKey(p => p.CustomerID);

            modelBuilder.Entity<PurchaseProduct>()
                .HasKey(pp => new { pp.PurchaseID, pp.ProductID }); 

            modelBuilder.Entity<PurchaseProduct>()
                .HasOne(pp => pp.Purchase)
                .WithMany(p => p.PurchaseProducts)
                .HasForeignKey(pp => pp.PurchaseID); 

            modelBuilder.Entity<PurchaseProduct>()
                .HasOne(pp => pp.Product)
                .WithMany(p => p.PurchaseProducts)
                .HasForeignKey(pp => pp.ProductID); 
        }
    }
}


