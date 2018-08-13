using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private Wedding _context;
        public HomeController(Wedding context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
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

                    return View("Index");
                }
                ModelState.AddModelError("password", "Passwords must match.");
            }
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string Password)
        {
            List<Users> user = _context.Users.Where(x => x.email == email).ToList();
            if(user != null && Password != null)
            {
                var Hasher = new PasswordHasher<Users>();
                foreach(var x in user){
                    if(0 != Hasher.VerifyHashedPassword(x, x.password, Password))
                    {
                        HttpContext.Session.SetInt32("user", x.id);
                        ViewBag.login="You successfully logged in.";
                        return Redirect("/dashboard");
                    }
                }
            }
            ViewBag.login="Please try logging in again.";
            return View("Index");
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            List<Weddings> data = _context.Weddings.Include(x => x.creator).Include(x => x.Guest).ThenInclude(y => y.Users).ToList();
            ViewBag.weddings = data;
            return View("Dashboard");
        }

        [HttpGet("plan")]
        public IActionResult Plan()
        {
            return View("Plan");
        }

        [HttpPost("wedding_create")]
        public IActionResult CreateWedding(Weddings NewWedding)
        {
            if(ModelState.IsValid)
            {
                _context.Weddings.Add(NewWedding);
                _context.SaveChanges();
                TempData["wedding_id"] = NewWedding.id;
                return RedirectToAction("Rsvp");
            }
            return View("Plan");
        }

        [HttpGet("wedding_delete/{id}")]
        public IActionResult MDelete(int id)
        {   
            Weddings dwedding = _context.Weddings.SingleOrDefault(m => m.id == id);
            var parent = _context.Weddings.Include(x => x.Guest).SingleOrDefault(m => m.id == id);
            foreach (var guest in parent.Guest.ToList()){
                _context.Guests.Remove(guest);
            }
            _context.Weddings.Remove(dwedding);
            _context.SaveChanges();
            List<Weddings> data = _context.Weddings.Include(x => x.creator).Include(x => x.Guest).ThenInclude(y => y.Users).ToList();
            ViewBag.weddings = data;
            return View("Dashboard");
        }
        
        [HttpGet("wedding/{id}")]
        public IActionResult Wedding(int id)
        {
            List<Weddings> data = _context.Weddings.Where(x => x.id == id).Include(x => x.creator).Include(x => x.Guest).ThenInclude(y => y.Users).ToList();
            ViewBag.weddings = data;
            string address = _context.Weddings.FirstOrDefault(x => x.id == id).address.ToString();
            ViewBag.address = address.Replace(" ", "+");
            return View("Wedding");
        }

        [HttpGet("rsvp")]
        public IActionResult Rsvp()
        {
            if (ModelState.IsValid){
                int? user = HttpContext.Session.GetInt32("user");
                int user_id = _context.Users.FirstOrDefault(x => x.id == user).id;
                Guests NewGuest = new Guests(){
                    UsersId = user_id,
                    WeddingId = (int)TempData["wedding_id"]
                };
                _context.Guests.Add(NewGuest);
                _context.SaveChanges();
            }
            List<Weddings> data = _context.Weddings.Where(x => x.id == (int)TempData["wedding_id"]).Include(x => x.creator).Include(x => x.Guest).ThenInclude(y => y.Users).ToList();
            ViewBag.weddings = data;
            string address = _context.Weddings.FirstOrDefault(x => x.id == (int)TempData["wedding_id"]).address.ToString();
            ViewBag.address = address.Replace(" ", "+");
            return View("Wedding");
        }

        [HttpGet("add_rsvp/{id}")]
        public IActionResult Rsvp(int id)
        {
            if (ModelState.IsValid){
                int? user = HttpContext.Session.GetInt32("user");
                int user_id = _context.Users.FirstOrDefault(x => x.id == user).id;
                Guests NewGuest = new Guests(){
                    UsersId = user_id,
                    WeddingId = id
                };
                _context.Guests.Add(NewGuest);
                _context.SaveChanges();
            }
            List<Weddings> data = _context.Weddings.Where(x => x.id == id).Include(x => x.creator).Include(x => x.Guest).ThenInclude(y => y.Users).ToList();
            ViewBag.weddings = data;
            string address = _context.Weddings.FirstOrDefault(x => x.id == id).address.ToString();
            ViewBag.address = address.Replace(" ", "+");
            return View("Wedding");
        }

        [HttpGet("delete_rsvp/{id}")]
        public IActionResult DeleteRsvp(int id)
        {
            var parent = _context.Weddings.Include(x => x.Guest).SingleOrDefault(m => m.id == id);
            foreach (var guest in parent.Guest.ToList()){
                if (HttpContext.Session.GetInt32("user") == guest.UsersId){
                    _context.Guests.Remove(guest);
                }
            }
            _context.SaveChanges();
        
            List<Weddings> data = _context.Weddings.Include(x => x.creator).Include(x => x.Guest).ThenInclude(y => y.Users).ToList();
            ViewBag.weddings = data;

            return View("Dashboard");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
