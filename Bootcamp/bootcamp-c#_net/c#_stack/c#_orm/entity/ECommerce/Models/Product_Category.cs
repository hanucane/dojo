using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product_Category
    {
        public int id { get; set; }
        [ForeignKey("ProductsId")]
        public int ProductsId { get; set; }
        public Products Product { get; set; }
        [ForeignKey("CategoriesId")]
        public int CategoriesId { get; set; }
        public Categories Category { get; set; }

    }
}