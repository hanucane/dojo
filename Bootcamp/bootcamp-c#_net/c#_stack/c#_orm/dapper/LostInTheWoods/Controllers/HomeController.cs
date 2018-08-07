using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LostInTheWoods.Models;
using DapperApp.Factories;

namespace LostInTheWoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;
        public HomeController()
        {
            trailFactory = new TrailFactory();
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Trails = trailFactory.FindAll();
            return View();
        }

        [HttpGet("newtrail")]
        public IActionResult NewTrail()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpGet]
        [Route("trails/{id}")]
        public IActionResult Trails(int id)
        {
            if(ModelState.IsValid)
            ViewBag.Trails = trailFactory.FindByID(id);
            return View();
        }

        [HttpPost("process")]
        public IActionResult Process(Trail data)
        {
            if(ModelState.IsValid)
            {
                trailFactory.Add(data);
                return RedirectToAction("Index");
            }
            return View("NewTrail");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}