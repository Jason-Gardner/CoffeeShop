using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;
using System.Text.Json;

namespace CoffeeShop.Controllers
{
    public class OrdersController : Controller
    {
        private List<Orders> orderList;

        private void GetOrders()
        {
            ShopDBContext db = new ShopDBContext();
            orderList = db.Orders.ToList();
        }

        public IActionResult ShoppingCart()
        {
            GetOrders();

            Client tempUser = JsonSerializer.Deserialize<Client>(TempData.Peek("user").ToString());
            List<Orders> yourCart = new List<Orders>();

            foreach (var item in orderList)
            {
                if (item.UserId == tempUser.Id)
                {
                    yourCart.Add(item);
                }
            }

            return View("Review", yourCart);
        }
    }
}