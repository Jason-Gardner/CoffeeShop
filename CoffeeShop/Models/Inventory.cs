using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Inventory
    {
        public string ProductName { get; set; }
        public int Inventory1 { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
    }
}
