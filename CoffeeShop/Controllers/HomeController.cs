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

        private List<Inventory> itemList;
        private List<Client> clientList;

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
            clientList = db.Client.ToList();
        }

        public IActionResult buyItem(int itemID)
        {
            if ((bool)TempData.Peek("Login"))
            {
                GetData();

                Client tempUser = JsonSerializer.Deserialize<Client>(HttpContext.Session.Get("user"));
                Inventory tempItem = new Inventory();

                foreach (var item in itemList)
                {
                    if (item.ProductId == itemID)
                    {
                        tempItem = item;
                    }
                }

                if (tempItem.Quantity > 0 && tempUser.Balance >= tempItem.UnitPrice)
                {
                    tempItem.Quantity -= 1;
                    tempUser.Balance -= tempItem.UnitPrice;


                    foreach (var item in itemList)
                    {
                        if (item.ProductId == tempItem.ProductId)
                        {
                            item.Quantity = tempItem.Quantity;
                        }
                    }

                    foreach (var user in clientList)
                    {
                        if (user.Id == tempUser.Id)
                        {
                            user.Balance = tempUser.Balance;
                        }
                    }
                    SaveItem(itemList);
                    SaveUsers(clientList);

                    ShopDBContext db = new ShopDBContext();
                    db.Orders.Add(new Orders { UserId = tempUser.Id, ItemId = tempItem.ProductId });
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

        public IActionResult Register()
        {
            return View();
        }


        public IActionResult Login(string username, string password)
        {
            return View();
        }


        public IActionResult Check(string username, string password)
        {
            GetData();

            foreach (var user in clientList)
            {
                if (user.UserName == username && user.Password == password)
                {
                    HttpContext.Session.SetString("user", JsonSerializer.Serialize(user));
                    TempData["Login"] = true;
                    TempData.Keep("Login");
                    return View("Profile");
                }
            }

            ViewBag.Message = "Incorrect Password";
            return View("Login");
        }

        public IActionResult Logout()
        {
            TempData["Login"] = false;
            HttpContext.Session.Clear();

            return View("Index");
        }

        public IActionResult Index()
        {
            // Use [Databasename]Context object to access the DB data
            ShopDBContext db = new ShopDBContext();
            var testObj = new Client();

            if (TempData.Peek("Login") == null)
            {
                TempData["Login"] = false;
                TempData.Keep("Login");
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

        public static void SaveUsers(List<Client> list)
        {
            ShopDBContext db = new ShopDBContext();

            foreach (var item in list)
            {
                db.Client.Update(item);
                db.SaveChanges();
            }
        }
    }
}
