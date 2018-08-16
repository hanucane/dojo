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
        public List<Product_Category> product_category { get; set; }
        public List<ProductImgs> product_img { get; set; }
        public int PricesId { get; set; }
        public Prices Prices { get; set; }
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public List<Order_Products> Order_Products { get; set; }

        public Products()
        {
            product_category = new List<Product_Category>();
            product_img = new List<ProductImgs>();
            Order_Products = new List<Order_Products>();
        }

    }
}