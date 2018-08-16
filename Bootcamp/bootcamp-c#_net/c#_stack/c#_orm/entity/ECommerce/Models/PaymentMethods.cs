using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class PaymentMethods 
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int UsersId { get; set; }
        public Users User { get; set; }
        public int BillingAddressesId { get; set; }
        public BillingAddresses BillingAddress { get; set; }
        public string card_type { get; set; }
        [Required]
        public string card_num { get; set; }
        public string card_exp { get; set; }
        [Required]
        public string card_name { get; set; }
        [Required]
        public int card_ccv { get; set; }
        public string nickname { get; set; }
    }
}
