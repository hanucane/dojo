using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class User
    {
        public User()
        {
            accounts = new List<Account>();
        }
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
        [MinLength(8, ErrorMessage="Password must be at least 8 characters")]
        public string password { get; set; }
        public List<Account> accounts { get; set; }
    }
}