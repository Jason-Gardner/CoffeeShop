using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            Orders = new HashSet<Orders>();
        }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
