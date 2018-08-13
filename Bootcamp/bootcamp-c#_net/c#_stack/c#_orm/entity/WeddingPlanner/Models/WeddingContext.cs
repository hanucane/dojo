using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class Wedding : DbContext
    {
        public Wedding(DbContextOptions<Wedding> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Guests> Guests { get; set; }
        public DbSet<Weddings> Weddings { get; set; }

    }
}