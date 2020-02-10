using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }

        public virtual Inventory Item { get; set; }
        public virtual Client User { get; set; }
    }
}
