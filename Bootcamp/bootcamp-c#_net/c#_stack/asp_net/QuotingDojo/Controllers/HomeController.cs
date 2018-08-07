using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult Quote(Quotes data)
        {
            string query = $"INSERT INTO Quotes(name, quote) VALUES ('{data.name}', '{data.quote}')";
            DbConnector.Execute(query);
            List<Dictionary<string, object>> Quotes = DbConnector.Query("SELECT * FROM Quotes ORDER BY created_at DESC");
            ViewBag.Quotes = Quotes;
            return View("Quotes");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> Quotes = DbConnector.Query("SELECT * FROM Quotes ORDER BY created_at DESC");
            ViewBag.Quotes = Quotes;
            return View("Quotes");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
