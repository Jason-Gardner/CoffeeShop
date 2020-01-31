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

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult buyItem(int itemID)
        {
            if ((bool)TempData.Peek("Login"))
            {
                ShopDBContext dbinv = new ShopDBContext();
                ShopDBContext inv = new ShopDBContext();
                User tempUser = JsonSerializer.Deserialize<User>(TempData.Peek("user").ToString());

                foreach (Inventory item in inv.Inventory)
                {
                    if (itemID == item.ProductId)
                    {
                        if (item.Inventory1 > 0)
                        {
                            TempData["item"] = item.ProductName;

                            foreach (var user in dbinv.User)
                            {
                                if (tempUser.Id == user.Id)
                                {
                                    if (user.Balance > item.UnitPrice)
                                    {
                                        user.Balance -= item.UnitPrice;
                                        item.Inventory1 -= 1;
                                        TempData["bought"] = item.ProductName;
                                        TempData["balance"] = user.Balance;
                                    }
                                    else
                                    {
                                        TempData["broke"] = "This item costs $" + String.Format("{0:0.00}", item.UnitPrice) + ", you have $" + String.Format("{0:0.00}", user.Balance) + " in your account.";
                                    }
                                }
                            }
                            dbinv.SaveChanges();
                            
                        }
                    }
                }
                inv.SaveChanges();
                return View("Review");
            }

            else
            {
                ViewBag.Message = "Please log in to complete your order.";
                return View("Login");
            }
        }


        public IActionResult Review()
        {
            return View();
        }


        public IActionResult Login(string username, string password)
        {
            return View();
        }

        
        public IActionResult Check(string username, string password)
        {
            ShopDBContext db = new ShopDBContext();

            foreach (var user in db.User)
            {
                if (user.UserName == username && user.Password == password)
                {
                    TempData["user"] = JsonSerializer.Serialize(user);
                    TempData.Keep("user");
                    TempData["Login"] = true;
                    TempData.Keep("Login");
                    return View("Profile");
                }
            }

            ViewBag.Message = "Incorrect Password";
            return View();
        }

        public IActionResult Logout()
        {
            TempData["Login"] = false;
            TempData["user"] = "";

            return View("Index");
        }

        public IActionResult Index()
        {
            // Use [Databasename]Context object to access the DB data
            ShopDBContext db = new ShopDBContext();
            var testObj = new User();

            if (TempData["Login"] == null)
            {
                TempData["Login"] = false;
                foreach (var cookie in Request.Cookies.Keys)
                {
                    Response.Cookies.Delete(cookie);
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult createUser(User user)
        {
            ShopDBContext db = new ShopDBContext();

            // Use db object to access the table we want to write data to
            db.User.Add(user);

            db.SaveChanges();

            return View(user);
        }

        [HttpPost]
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
    }
}
