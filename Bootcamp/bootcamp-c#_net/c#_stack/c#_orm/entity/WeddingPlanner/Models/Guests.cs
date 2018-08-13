using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Guests
    {
        public int id { get; set; }
        [ForeignKey("UserId")]
        public int UsersId { get; set; }
        public Users Users { get; set; }
        [ForeignKey("WeddingId")]
        public int WeddingId { get; set; }
        public Weddings Wedding { get; set; }
    }
}