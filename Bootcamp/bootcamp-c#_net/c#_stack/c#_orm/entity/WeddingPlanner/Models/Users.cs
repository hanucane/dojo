using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Users : BaseEntity
    {
        public int id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage="First name must be at least 2 characters")]
        public string first_name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage="Last name must be at least 2 characters")]
        public string last_name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage="Please enter a valid e-mail")]
        public string email { get; set; }
        [Required]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{4,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string password { get; set; }
        public List<Guests> Guest { get; set; }
        public List<Weddings> Wedding { get; set; }

        public Users()
        {
            Guest = new List<Guests>();
            Wedding = new List<Weddings>();
        }
    }
}