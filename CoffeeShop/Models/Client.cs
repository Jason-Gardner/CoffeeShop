﻿using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Accounttype { get; set; }
        public string Password { get; set; }
        public decimal? Balance { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
