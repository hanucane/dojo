using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class AdminController : Controller
    {
        private Customer _context;
        public AdminController(Customer context)
        {
            _context = context;
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View("Contact");
        }
        
        [HttpGet("admin/usermanage")]
        public IActionResult ManageUsers()
        {
            ViewBag.users = _context.Users.ToList();
            return View("UserManage");
        }

        [HttpGet("admin/userdelete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("ManageUsers");
        }
    }
}
