using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RESTauranter.Models
{
    public class Review : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Review(DbContextOptions<Review> options) : base(options) { }
        public DbSet<Reviews> Reviews { get; set; }
    }
}
