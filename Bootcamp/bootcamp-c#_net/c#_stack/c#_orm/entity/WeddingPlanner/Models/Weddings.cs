using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Weddings
    {
        public int id { get; set; }
        public string bride { get; set; }
        public string groom { get; set; }
        public DateTime date { get; set; }
        public string address { get; set; }
        public List<Guests> Guest { get; set; }
        public int CreatorId { get; set; }
        public Users creator { get; set; }

        public Weddings()
        {
            Guest = new List<Guests>();
        }
    }
}