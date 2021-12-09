using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork.Models;
using HomeWork.Models.Entities;
using HomeWork.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers
{
    public class RegisterController : Controller
    {
        private UserService _userService;
        private UserManager<CustomUser> _userManager;

        public RegisterController(UserService userService, UserManager<CustomUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(RegisterViewModel data)
        {
            if (!data.PasswordConfirmed())
            {
                ModelState.AddModelError("ConfirmPassword", "Hasła nie są takie same");
            }

            if (!ModelState.IsValid)
            {
                return View(data);
            }

            var entity = new CustomUser
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                UserName = data.Login,
                AboutMe = data.AboutMe
                
            };

            var result = _userManager.CreateAsync(entity, data.Password).Result;

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(data);
        }
    }
}
