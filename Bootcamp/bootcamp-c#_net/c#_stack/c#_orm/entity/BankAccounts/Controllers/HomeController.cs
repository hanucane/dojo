using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BankAccounts.Models;

namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private Users _context;
        public HomeController(Users context)
        {
            _context = context;
        }
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
