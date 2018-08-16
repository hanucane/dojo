using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
    public class Customer : DbContext
    {
        public Customer(DbContextOptions<Customer> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Product_Category> Product_Category { get; set; }
        public DbSet<Prices> Prices { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<ProductImgs> ProductImgs { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<BillingAddresses> BillingAddresses { get; set; }
        public DbSet<ShippingAddresses> ShippingAddresses { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Order_Products> Order_Products { get; set; }
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