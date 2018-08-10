using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{
    public class Messages : BaseEntity
    {
        public Messages()
        {
            comments = new List<Comments>();
        }
        public int id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public string message { get; set; }
        public List<Comments> comments { get; set; }
        
    }
}
