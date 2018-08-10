using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{
    public class Comments : BaseEntity
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int MessageId { get; set; }
        public Messages Message { get; set; }
        [Required]
        public string comment { get; set; }
        
    }
}