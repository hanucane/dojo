using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class Account
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int balance { get; set; }
        public int change { get; set; }
        public DateTime created_at { get; set; }
    }
}