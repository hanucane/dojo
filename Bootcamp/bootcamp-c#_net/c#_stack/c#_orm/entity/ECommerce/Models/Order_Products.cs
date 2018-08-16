using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Order_Products : BaseEntity 
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int OrdersId { get; set; }
        public Orders Order { get; set; }
        [Required]
        public int ProductsId { get; set; }
        public Products Product { get; set; }
        public int quantity { get; set; }
        public decimal cost { get; set; }
    }
}