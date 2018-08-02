using Microsoft.AspNetCore.Mvc;
namespace FirstASP.Controllers     //be sure to use your own project's namespace!
{
    public class HelloController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public IActionResult Index()
        {
            return View();
        }

        // [HttpGet]
        // [Route("projects")]
        // public JsonResult Method(string name)
        // {
        //     // Method body
        // }
        // [HttpGet]
        // [Route("template/{id}/{action}")]
        // public JsonResult Method(int id, string action)
        // {
        //     // Method body
        // }

        // public IActionResult Method()
        // {
        //     // The anonymous object consists of keys and values
        //     // The keys should match the parameter names of the method being redirected to
        //     return RedirectToAction("OtherMethod", new { Food = "sandwiches", Quantity = 5 });
        // }
        
        // [HttpGet]
        // [Route("other/{Food}/{Quantity}")]
        // public IActionResult OtherMethod(string Food, int Quantity)
        // {
        //     Console.WriteLine($"I ate {Quantity} {Food}.");
        //     // Writes "I ate 5 sandwiches."
        // }

        // public class FirstController : Controller
        // {
        //     public IActionResult Method()
        //     {
        //         return RedirectToAction("OtherMethod", "Second");
        //     }
        // }
        
        // // In another file
        // public class SecondController : Controller
        // {
        //     public IActionResult OtherMethod()
        //     {
        //         return View();
        //     }
        // }


    }
}
