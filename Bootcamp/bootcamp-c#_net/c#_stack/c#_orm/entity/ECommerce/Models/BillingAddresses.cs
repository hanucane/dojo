using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class BillingAddresses
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int UsersId { get; set; }
        public Users User { get; set; }
        public List<PaymentMethods> PaymentMethods { get; set; }
        [Required]
        public string address1 { get; set; }
        public string address2 { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public int zip_code { get; set; }
        public string nickname { get; set; }

        public BillingAddresses()
        {
            PaymentMethods = new List<PaymentMethods>();
        }
    }
}