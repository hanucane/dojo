using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Randomizer.Models;

namespace Randomizer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[14];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            HttpContext.Session.SetString("random", finalString);
            string ranString = HttpContext.Session.GetString("random");
            HttpContext.Session.SetInt32("count", 1);
            int? count = HttpContext.Session.GetInt32("count");
            return View();
        }

        [Route("generate")]
        public IActionResult Generate()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[14];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            HttpContext.Session.SetString("random", finalString);
            int? count = HttpContext.Session.GetInt32("count");
            count++;
            HttpContext.Session.SetInt32("count", (int)count);
            return View("Index");
        }

        [Route("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[14];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            HttpContext.Session.SetString("random", finalString);
            string ranString = HttpContext.Session.GetString("random");
            HttpContext.Session.SetInt32("count", 1);
            int? count = HttpContext.Session.GetInt32("count");
            
            return View("Index");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
