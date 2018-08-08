using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LoginRegistration.Models;


namespace LoginRegistration.Controllers
{
    public class HomeController : Controller
    {
        private Users _context;
        public HomeController(Users context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Process(User NewUser, string confirm_password)
        {
            if(ModelState.IsValid)
            {
                if (NewUser.password == confirm_password){
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    NewUser.password = Hasher.HashPassword(NewUser, NewUser.password);
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetString("login", NewUser.email);

                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("password", "Passwords must match.");
            }
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string Password)
        {
            // Attempt to retrieve a user from your database based on the Email submitted
            List<User> user = _context.user.Where(x => x.email == email).ToList();
            if(user != null && Password != null)
            {
                var Hasher = new PasswordHasher<User>();
                foreach(var x in user){
                    if(0 != Hasher.VerifyHashedPassword(x, x.password, Password))
                    {
                        HttpContext.Session.SetString("login", x.email);
                        ViewBag.login="You successfully logged in.";
                        return RedirectToAction("Index");
                    }
                }
                
            }
            ViewBag.login="Please try logging in again.";
            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
