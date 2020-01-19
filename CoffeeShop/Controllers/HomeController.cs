using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Need 1 Action to load registration
        public IActionResult Register()
        {
            return View();
        }

        // Need 1 Action to take those user inputs and display the user name
        public IActionResult NewUser(string userName, string email, string password)
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult createUser(string accountType, string userName, string firstName, string lastName, string email, string phone, string password)
        {
            Person User = new Person();
            User.accountType = accountType;
            User.userName = userName;
            User.firstName = firstName;
            User.lastName = lastName;
            User.email = email;
            User.phone = phone;
            User.password = password;

            return View(User);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
