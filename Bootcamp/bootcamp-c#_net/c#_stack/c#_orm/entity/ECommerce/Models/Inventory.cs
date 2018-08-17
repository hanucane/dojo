using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Inventory : BaseEntity
    {
        public int id { get; set; }
        public int quantity_new { get; set; }
        public int quantity_used { get; set; }
        public int quantity_defect { get; set; }
        public int quantity_sold { get; set; }
        [ForeignKey("Products")]
        public int ProductsId { get; set; }
        public Products Product { get; set; }
    }
}