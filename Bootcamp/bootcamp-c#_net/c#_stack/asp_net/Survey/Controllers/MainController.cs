using Microsoft.AspNetCore.Mvc;
namespace Survey.Controllers
{
    public class MainController : Controller   
    {
        
        [HttpGet]       
        [Route("")]     
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]       
        [Route("result")]     
        public IActionResult Result(string name, string email, string dojo_location, string fav_language, string comments)
        {
            ViewBag.name = name;
            ViewBag.email = email;
            ViewBag.dojo = dojo_location;
            ViewBag.language = fav_language;
            ViewBag.comments = comments;
            return View();
        }
        
    }
}