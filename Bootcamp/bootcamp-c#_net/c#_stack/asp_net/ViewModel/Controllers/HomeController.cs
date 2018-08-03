using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Models;


namespace ViewModel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            NewString example = new NewString()
            {
                _string = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam scelerisque eget mi quis accumsan. Maecenas tincidunt elit ut blandit volutpat. Duis finibus mauris venenatis mi auctor dapibus. Curabitur iaculis sapien id ipsum ultricies interdum eget et leo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Curabitur lorem elit, elementum eget augue at, posuere aliquam est. Donec sollicitudin sit amet quam at aliquam. Quisque sagittis lacinia metus, et maximus magna mattis eu. Cras in volutpat dolor, eget consequat tortor"
            };
            return View("NewString", example);
        }

        [Route("User")]
        public IActionResult NewUser()
        {
            NewUser example = new NewUser()
            {
                _name = "Moose Phillips"
            };
            return View("User", example);
        }

        [Route("Users")]
        public IActionResult Users()
        {
            List<string> users = new List<string>();
            users.Add("Moose Phillips");
            users.Add("Sarah");
            users.Add("Jerry");
            users.Add("Rene Ricky");
            users.Add("Barbarah");
            return View("Users", users);
        }

        [Route("Numbers")]
        public IActionResult Numbers()
        {
            List<int> num_list = new List<int>();
            num_list.Add(1);
            num_list.Add(2);
            num_list.Add(3);
            num_list.Add(10);
            num_list.Add(43);
            num_list.Add(5);
            return View("Numbers", num_list);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
