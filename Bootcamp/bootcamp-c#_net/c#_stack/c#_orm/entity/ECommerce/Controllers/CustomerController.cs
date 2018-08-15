using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class CustomerController : Controller
    {
        private Customer _context;
        public CustomerController(Customer context)
        {
            _context = context;
        }

        [HttpGet("registration")]
        public IActionResult Registration()
        {
            return View("Forms/Register");
        }

        [HttpPost("register")]
        public IActionResult Process(Users NewUser, string confirm_password)
        {
            if(ModelState.IsValid)
            {
                if (NewUser.password == confirm_password){
                    PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                    NewUser.password = Hasher.HashPassword(NewUser, NewUser.password);
                    _context.Users.Add(NewUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("user", NewUser.id);

                    return Redirect("/");
                }
                ModelState.AddModelError("password", "Passwords must match.");
            }
            return View("Forms/Register");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View("Forms/Login");
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string Password)
        {
            var user = _context.Users.FirstOrDefault(x => x.email == email);
            if(user != null && Password != null)
            {
                var Hasher = new PasswordHasher<Users>();
                if(0 != Hasher.VerifyHashedPassword(user, user.password, Password))
                {
                    HttpContext.Session.SetInt32("user", user.id);
                    HttpContext.Session.SetInt32("user_level", user.user_level);
                    ViewBag.login="You successfully logged in.";
                    return Redirect("/");
                }
            }
            ViewBag.login="Please try logging in again.";
            return View("Forms/Login");
        }

    }
}