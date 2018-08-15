using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Categories : BaseEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Product_Category> product_category { get; set; }

        public Categories()
        {
            product_category = new List<Product_Category>();
        }
    }
}
