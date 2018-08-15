using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Products : BaseEntity
    {
        public int id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage="Product name must be at least 2 characters")]
        public string name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage="Product description must be at least 10 characters")]
        public string description { get; set; }
        public string img_url { get; set; }
        public List<Product_Category> product_category { get; set; }
        public int PricesId { get; set; }
        public Prices Prices { get; set; }
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public Products()
        {
            product_category = new List<Product_Category>();
        }

    }
}