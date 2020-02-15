using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private List<Inventory> itemList;
        private List<AspNetUsers> clientList;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult History()
        {
            ShopDBContext db = new ShopDBContext();
            List<Orders> userHistory = new List<Orders>();

            Client tempUser = JsonSerializer.Deserialize<Client>(HttpContext.Session.Get("user"));
            Inventory tempItem = new Inventory();

            foreach (var item in db.Orders)
            {
                if (item.UserId == tempUser.Id)
                {
                    userHistory.Add(item);
                }
            }

            HttpContext.Session.SetString("orders", JsonSerializer.Serialize(userHistory));

            return View(db);
        }

        public IActionResult Search(int itemNum)
        {
            GetData();

            Inventory tempItem = new Inventory();

            foreach (var item in itemList)
            {
                if (item.ProductId == itemNum)
                {
                    tempItem = item;
                }
            }

            return View("About", tempItem);
        }

        public IActionResult About()
        {
            return View();
        }

        private void GetData()
        {
            ShopDBContext db = new ShopDBContext();
            itemList = db.Inventory.ToList();
            clientList = db.AspNetUsers.ToList();
        }

        [Authorize]
        public IActionResult buyItem(int itemID)
        {
            GetData();

            AspNetUsers user = new AspNetUsers();
            Inventory tempItem = new Inventory();

            foreach (var item in itemList)
            {
                if (item.ProductId == itemID)
                {
                    tempItem = item;
                }
            }

            foreach (var client in clientList)
            {
                if (client.Email == User.Identity.Name)
                {
                    user = client;
                }
            }

            if (tempItem.Quantity > 0 && user.Balance >= tempItem.UnitPrice)
            {
                tempItem.Quantity -= 1;
                user.Balance -= tempItem.UnitPrice;


                foreach (var item in itemList)
                {
                    if (item.ProductId == tempItem.ProductId)
                    {
                        item.Quantity = tempItem.Quantity;
                    }
                }

                foreach (var client in clientList)
                {
                    if (user.Email == User.Identity.Name)
                    {
                        client.Balance = user.Balance;
                    }
                }

                SaveItem(itemList);
                SaveUsers(clientList);

                ShopDBContext db = new ShopDBContext();
                db.Orders.Add(new Orders { UserId = User.Identity.GetHashCode(), ItemId = tempItem.ProductId });
                db.SaveChanges();
                return View("Review", tempItem);

            }
            else if (tempItem.Quantity <= 0)
            {
                ViewBag.Message = "Not enough in stock to purchase.";
                return View("Review");
            }
            else
            {
                ViewBag.Message = "Not enough funds in your account.";
                return View("Review");
            }
        }

        public IActionResult Review()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }


        //public IActionResult Check(string username, string password)
        //{
        //    GetData();

        //    foreach (var user in clientList)
        //    {
        //        if ()
        //        {
        //            HttpContext.Session.SetString("user", JsonSerializer.Serialize(user));
        //            TempData["Login"] = true;
        //            TempData.Keep("Login");
        //            return View("Profile");
        //        }
        //    }

        //    ViewBag.Message = "Incorrect Password";
        //    return View("Login");
        //}

        public IActionResult Logout()
        {
            TempData["Login"] = false;
            HttpContext.Session.Clear();

            return View("Index");
        }

        public IActionResult Index()
        {

            if (User != null && HttpContext.Session.Get("user") == null)
            {
                GetData();

                foreach (var client in clientList)
                {
                    if (client.Email == User.Identity.Name)
                    {
                        HttpContext.Session.SetString("user", JsonSerializer.Serialize(client));
                    }
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult createUser(Client user)
        {
            ShopDBContext db = new ShopDBContext();

            // Use db object to access the table we want to write data to
            db.Client.Add(user);

            //we can build it as we add it
            // db.User.Add(new User() { Name = "Something....", Email = ... etc.}

            db.SaveChanges();

            return View(user);
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Order()
        {
            ShopDBContext InvList = new ShopDBContext();
            return View(InvList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static void SaveItem(List<Inventory> list)
        {
            ShopDBContext db = new ShopDBContext();

            foreach (var item in list)
            {
                db.Inventory.Update(item);
                db.SaveChanges();
            }
        }

        public static void SaveUsers(List<AspNetUsers> list)
        {
            ShopDBContext db = new ShopDBContext();

            foreach (var item in list)
            {
                db.AspNetUsers.Update(item);
                db.SaveChanges();
            }
        }
    }
}
