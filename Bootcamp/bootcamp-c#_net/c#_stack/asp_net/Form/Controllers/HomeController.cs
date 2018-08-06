using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Form.Models;

namespace Form.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("register")]
        public IActionResult Create(Register user)
        {
            if(ModelState.IsValid)
            {
                return View("Registered", user);
            }
            else
            {
                return View("Index");
            }
        } 
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
