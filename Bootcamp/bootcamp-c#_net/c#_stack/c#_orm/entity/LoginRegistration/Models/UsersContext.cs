using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LoginRegistration.Models
{
    public class Users : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Users(DbContextOptions<Users> options) : base(options) { }
        public DbSet<User> user { get; set; }
    }
}