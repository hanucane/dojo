using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private Review _context;
        public HomeController(Review context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("review")]
        public IActionResult Process(Reviews NewReview)
        {
            if(ModelState.IsValid)
            {
                _context.Add(NewReview);
                _context.SaveChanges();

                return RedirectToAction("ReviewList");
            }
            return View("Index");
        }

        [HttpGet("reviews")]
        public IActionResult ReviewList()
        {
            List<Reviews> all_reviews = _context.Reviews.OrderBy(p => p.review_date).ToList();
            ViewBag.all_reviews = all_reviews;
            return View("Reviews");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
