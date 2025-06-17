using Microsoft.EntityFrameworkCore;
using OMSModels.Models;

namespace OMSModels.Data
{
    public class OMSContext : DbContext
    {
        public OMSContext(DbContextOptions<OMSContext> options) : base(options) { }

        public DbSet<Shopper> Shoppers { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shopper>().ToTable("Shopper");
            modelBuilder.Entity<Basket>().ToTable("Basket");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<BasketItem>().ToTable("BasketItem");
        }
    }
}
