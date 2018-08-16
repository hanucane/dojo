using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Cart : BaseEntity
    {
        public int id { get; set; }

        public int UsersId { get; set; }
        public Users User { get; set; }
        public int ProductsId { get; set; }
        public Products Product { get; set; }
        public int quantity { get; set; }
        public decimal cost { get; set; }
        
    }
}
