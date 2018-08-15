using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class ProductImgs
    {
        public int id { get; set; }
        public int ProductsId { get; set; }
        public Products Product { get; set; }
        [Required]
        public string img_url { get; set; }
    }
}