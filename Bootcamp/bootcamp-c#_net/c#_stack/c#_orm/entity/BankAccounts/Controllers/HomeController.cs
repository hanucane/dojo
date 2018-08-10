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
                    HttpContext.Session.SetInt32("login", NewUser.id);

                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("password", "Passwords must match.");
            }
            return View("Index");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View("Login");
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
                        HttpContext.Session.SetInt32("login", x.id);
                        ViewBag.login="You successfully logged in.";
                        return RedirectToAction("account", new {id = (int)x.id});
                    }
                }
            }
            ViewBag.login="Please try logging in again.";
            return View("Login");
        }

        [HttpGet("account/{id}")]
        public IActionResult Accounts(int id)
        {
            if (HttpContext.Session.GetInt32("login") == id){
                var data = _context.user.Where(x => x.id == id).Include(x => x.accounts).FirstOrDefault();
                return View("Account", data);
            }
            ViewBag.login="You have to be logged in to see your account";
            return View("Login");
        }

        [HttpPost("transaction")]
        public IActionResult Transaction(int change_val, string change_type)
        {
            int? id = HttpContext.Session.GetInt32("login");
            int user_id = _context.user.Where(x => x.id == id).FirstOrDefault().id;
            Account data = _context.account.Where(x => x.UserId == id).LastOrDefault();
            DateTime current = DateTime.Now;
            if (change_type == "deposit"){
                if (data == null){
                    Account NewAccount = new Account(){
                        balance = change_val,
                        change = change_val,
                        UserId = user_id,
                        created_at = current
                    };
                    _context.account.Add(NewAccount);
                    _context.SaveChanges();
                }
                else {
                    Account NewAccount = new Account(){
                        balance = data.balance + change_val,
                        change = change_val,
                        UserId = user_id,
                        created_at = current
                    };
                    _context.account.Add(NewAccount);
                    _context.SaveChanges();
                }
            }
            else if (change_type == "withdrawal"){
                if (data == null){
                    ViewBag.error = "Need to make a deposit before making a withdrawal.";
                }
                else {
                    if (change_val > data.balance){
                        ViewBag.error = "Cannot withdraw more funds than you have available.";
                    }
                    else {
                        Account NewAccount = new Account(){
                            balance = data.balance - change_val,
                            change = -change_val,
                            UserId = user_id,
                            created_at = current
                        };
                        _context.account.Add(NewAccount);
                        _context.SaveChanges();
                    }
                }
            }
            return RedirectToAction("account", new {id = id});
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
