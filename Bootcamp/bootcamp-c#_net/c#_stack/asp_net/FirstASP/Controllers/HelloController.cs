using Microsoft.AspNetCore.Mvc;
namespace FirstASP.Controllers     //be sure to use your own project's namespace!
{
    public class HelloController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public string Index()
        {
            return "Hello World from HelloController!";
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

    }
}
