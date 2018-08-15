using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
    public class Customer : DbContext
    {
        public Customer(DbContextOptions<Customer> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
    }
}