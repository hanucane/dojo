using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheWall.Models;

namespace TheWall.Controllers
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
                    HttpContext.Session.SetInt32("user", NewUser.id);

                    return Redirect("wall/"+HttpContext.Session.GetInt32("user"));
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
                        HttpContext.Session.SetInt32("user", x.id);
                        ViewBag.login="You successfully logged in.";
                        return Redirect("wall/"+HttpContext.Session.GetInt32("user"));
                    }
                }
            }
            ViewBag.login="Please try logging in again.";
            return View("Login");
        }

        [HttpGet("wall/{id}")]
        public IActionResult Wall(int id)
        {
            List<Messages> message = _context.messages.Include(x=>x.User).Include(x => x.comments).ThenInclude(y => y.User).ToList();
            ViewBag.message = message;
            return View("Wall");
        }

        [HttpPost("message")]
        public IActionResult Message(Messages NewMessage)
        {
            if(ModelState.IsValid)
            {
                _context.messages.Add(NewMessage);
                _context.SaveChanges();
                ViewBag.success = "Successfully added new message";
                List<Messages> message = _context.messages.Include(x=>x.User).Include(x => x.comments).ThenInclude(y => y.User).ToList();
                ViewBag.message = message;
                return Redirect("wall/"+HttpContext.Session.GetInt32("user"));
            }
            ViewBag.error = "Unable to add message. Please try again";
            return View("Wall");
        }

        [HttpPost("message_delete")]
        public IActionResult MDelete(int message_id)
        {
            List<Messages> message = _context.messages.Include(x=>x.User).Include(x => x.comments).ThenInclude(y => y.User).ToList();
            ViewBag.message = message;
            Messages dmessage = _context.messages.SingleOrDefault(m => m.id == message_id);
            var parent = _context.messages.Include(x => x.comments).SingleOrDefault(m => m.id == message_id);
            foreach (var comment in parent.comments.ToList()){
                _context.comments.Remove(comment);
            }
            _context.messages.Remove(dmessage);
            _context.SaveChanges();
            return Redirect("wall/"+HttpContext.Session.GetInt32("user"));
        }

        [HttpPost("comment")]
        public IActionResult Comment(Comments NewComment)
        {
            List<Messages> message = _context.messages.Include(x=>x.User).Include(x => x.comments).ThenInclude(y => y.User).ToList();
            ViewBag.message = message;
            if(ModelState.IsValid)
            {
                _context.comments.Add(NewComment);
                _context.SaveChanges();
                ViewBag.success = "Successfully added new comment";
                
                return Redirect("wall/"+HttpContext.Session.GetInt32("user"));
            }
            ViewBag.error = "Unable to add comment. Please try again";
            return View("Wall");
        }

        [HttpPost("comment/delete")]
        public IActionResult CDelete(int comment_id)
        {
            List<Messages> message = _context.messages.Include(x=>x.User).Include(x => x.comments).ThenInclude(y => y.User).ToList();
            ViewBag.message = message;
            Comments comment = _context.comments.SingleOrDefault(m => m.id == comment_id);
            _context.comments.Remove(comment);
            _context.SaveChanges();
            return View("Wall");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
