using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HomeWork.Models;
using HomeWork.Models.Services;

namespace HomeWork.Controllers
{
    public class HomeController : Controller
    {
        private UserService _userService;
        private readonly ILogger<HomeController> _logger;
        public HomeController(UserService userService)
        {
            _userService = userService;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ListofUsers()
        {
            var vm = new UsersListViewModel
            {
                Users = _userService.GetAll()
            };
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
