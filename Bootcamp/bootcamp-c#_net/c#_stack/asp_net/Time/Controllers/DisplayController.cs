using Microsoft.AspNetCore.Mvc;
namespace Time.Controllers
{
    public class DisplayController : Controller   
    {
        
        [HttpGet]       
        [Route("")]     
        public IActionResult Index()
        {
            return View();
        }
    }
}