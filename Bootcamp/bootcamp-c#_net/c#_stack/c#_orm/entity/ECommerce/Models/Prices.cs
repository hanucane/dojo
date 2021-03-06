using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Prices
    {
        [Key]
        public int id { get; set; }
        [Required]
        public decimal new_price { get; set; }
        public decimal used { get; set; }
        [ForeignKey("Products")]
        public int ProductsId { get; set; }
        public Products Product { get; set; }
    }
}
