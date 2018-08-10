using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TheWall.Models
{
    public class Users : DbContext
    {
        public Users(DbContextOptions<Users> options) : base(options) { }
        public DbSet<User> user { get; set; }
        public DbSet<Messages> messages { get; set; }
        public DbSet<Comments> comments { get; set; }

    }
}