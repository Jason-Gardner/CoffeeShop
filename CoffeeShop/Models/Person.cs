using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class Person
    {
        List<List<string>> orderHistory { get; set; }
        public List<string> currentOrder { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string accountType { get; set; }

        public Person()
        {

        }
    }

    public class userOrder
    {
        
    }
}
