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

                User Person = new User();

                foreach (User item in dbinv.User)
                {
                    if (Response.Cookies.Equals(item.UserName))
                    {
                        Person = item;
                    }
                }

                foreach (Inventory item in dbinv.Inventory)
                {
                    if (itemID == item.ProductId)
                    {
                        if (item.Inventory1 > 0 )
                        {
                            Response.Cookies.Append("productName",item.ProductName);
                            //item.Inventory1 -= 1;
                            //dbinv.SaveChanges();
                            //Person.Funds -= item.unitprice;
                        }
                    }
                }
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

        [HttpGet]
        public IActionResult Check(string username, string password)
        {
            ShopDBContext db = new ShopDBContext();

            TempData.Peek("Login");

            foreach (var user in db.User)
            {
                if (user.UserName == username)
                {
                    if (user.Password == password)
                    {
                        TempData["Login"] = true;
                        TempData.Peek("Login");

                        Response.Cookies.Append("user", user.UserName);
                        Response.Cookies.Append("firstName", user.FirstName);
                        Response.Cookies.Append("lastName", user.LastName);
                        Response.Cookies.Append("email", user.Email);
                        Response.Cookies.Append("phone", user.Phone);
                        Response.Cookies.Append("account", user.Accounttype);

                        return View("Profile");
                    }
                }
            }

            ViewBag.Message = "Incorrect Password";
            return View();
        }

        public IActionResult Logout()
        {
            TempData["Login"] = false;
            return View("Index");
        }

        public IActionResult Index()
        {
            // Use [Databasename]Context object to access the DB data
            ShopDBContext db = new ShopDBContext();
            var testObj = new User();

            if (TempData.Peek("Login") == null)
            {
                TempData["Login"] = false;
                TempData.Peek("Login");
            }

            //foreach loop to pull out individual rows of data
            foreach (var user in db.User)
            {
                testObj = new User()
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Phone = user.Phone,
                    Accounttype = user.Accounttype,
                    Id = user.Id,
                    Password = user.Password
                };

                List<User> userList = new List<User>();
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

        public IActionResult Profile()
        {
            TempData.Peek("User");
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
