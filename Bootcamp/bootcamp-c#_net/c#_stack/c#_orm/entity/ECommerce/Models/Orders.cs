using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Orders : BaseEntity 
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int UsersId { get; set; }
        public Users User { get; set; }
        [Required]
        public int BillingAddressesId { get; set; }
        public BillingAddresses BillingAddress { get; set; }
        [Required]
        public int ShippingAddressesId { get; set; }
        public ShippingAddresses ShippingAddress { get; set; }
        [Required]
        public int PaymentMethodsId { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public string order_status { get; set; }
        public List<Order_Products> Order_Products { get; set; }
        public Orders()
        {
            Order_Products = new List<Order_Products>();
        }
    }
}
