using Microsoft.AspNetCore.Mvc;
using Survey.Models;
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
        public IActionResult Result(SurveyData results)
        {
            return View("Result", results);
        }
 

        [Route("survey/create")]
        public IActionResult Create(SurveyData results)
        {
            if(ModelState.IsValid)
            {
                return View("Result", results);
            }
            else
            {
                return View("Index");
            }
        }     
    }
}