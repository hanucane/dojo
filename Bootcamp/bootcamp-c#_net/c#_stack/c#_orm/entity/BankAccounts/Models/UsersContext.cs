using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Models
{
    public class Users : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Users(DbContextOptions<Users> options) : base(options) { }
        public DbSet<User> user { get; set; }
        public DbSet<Account> account { get; set; }
    }
}