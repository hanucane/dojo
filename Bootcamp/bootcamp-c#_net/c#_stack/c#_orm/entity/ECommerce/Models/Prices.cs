using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Prices
    {
        public int id { get; set; }
        public int new_price { get; set; }
        public int used { get; set; }
        [ForeignKey("Products")]
        public int ProductsId { get; set; }
        public Products Product { get; set; }
    }
}
