using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
    public class Store : DbContext
    {
        public Store(DbContextOptions<Store> options) : base(options) { }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Product_Category> Product_Category { get; set; }
        public DbSet<Prices> Prices { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>()
                .HasOne(p => p.Prices)
                .WithOne(i => i.Product)
                .HasForeignKey<Prices>(b => b.ProductsId);
            modelBuilder.Entity<Products>()
                .HasOne(p => p.Inventory)
                .WithOne(i => i.Product)
                .HasForeignKey<Inventory>(b => b.ProductsId);
        }
    }
}