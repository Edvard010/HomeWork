using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork.Models;
using HomeWork.Models.Entities;
using HomeWork.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers
{
    public class UserController : Controller
    {
        private UserService _userService;
        private SignInManager<CustomUser> _signInManager;
        private UserManager<CustomUser> _userManager;
        public void Options() { }

        public UserController(UserService userService,
            SignInManager<CustomUser> signInManager,
            UserManager<CustomUser> userManager)
        {
            _userService = userService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Edit()
        {
            var userId = _userManager.GetUserId(User); //ta linijka działa - podaje userId=3, czyli właściwy użytkownik, typ string
            int.TryParse(userId, out int id);
            var vm = _userService.GetToEdit(id);
            vm.UserId = userId; //string
            return View(vm);
        }
        
        [HttpPost]
        public IActionResult Edit(EditUserViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            _userService.Update(data);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel data)
        {
            var result = _signInManager.PasswordSignInAsync(data.UserName, data.Password, false, false).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Nieprawidłowe dane");
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public IActionResult ViewUser()
        {
            var userId = _userManager.GetUserId(User); //ta linijka działa - podaje userId=3, czyli właściwy użytkownik, typ string
            int.TryParse(userId, out int id);
            var vm = _userService.GetToView(id);
            vm.UserId = userId; //string
            return View(vm);
        }

    }
}
