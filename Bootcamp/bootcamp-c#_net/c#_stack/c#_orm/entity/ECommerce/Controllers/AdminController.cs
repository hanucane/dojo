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

        [HttpGet("admin/usercreate")]
        public IActionResult CreateUser()
        {
            return View("UserCreate");
        }

        [HttpPost("admin/usercreate")]
        public IActionResult CreateUser(Users newUser)
        {
            var user = _context.Users.FirstOrDefault(x => x.email == newUser.email);
            if (user == null){
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return RedirectToAction("ManageUsers");
            }
            @ViewBag.CreateUser = "User with that email already exists.";
            return View("UserCreate");
        }

        [HttpGet("admin/userdelete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("ManageUsers");
        }

        [HttpGet("admin/useredit/{id}")]
        public IActionResult EditView(int id)
        {
            ViewBag.user = _context.Users.FirstOrDefault(x => x.id == id);
            return View("UserEdit");
        }
        
        [HttpPost("admin/useredit/{id}")]
        public IActionResult EditUser(Users userEdit, int id)
        {
            ViewBag.user = _context.Users.FirstOrDefault(x => x.id == id);
            if(HttpContext.Session.GetInt32("user_level") == 9)
            {
                Users user = _context.Users.FirstOrDefault(x => x.id == id);
                user.first_name = userEdit.first_name;
                user.last_name = userEdit.last_name;
                user.email = userEdit.email;
                user.user_level = userEdit.user_level;
                _context.SaveChanges();
                ViewBag.EditSuccess = "You successfully edited user.";
                return View("UserEdit");
            }
            ViewBag.EditUser = "You must be an admin to edit users.";
            return View("UserEdit");
        }

        [HttpPost("admin/userpasswordedit/{id}")]
        public IActionResult EditUserPassword(Users userEdit, int id)
        {
            ViewBag.user = _context.Users.FirstOrDefault(x => x.id == id);
            if(HttpContext.Session.GetInt32("user_level") == 9)
            {
                Users user = _context.Users.FirstOrDefault(x => x.id == id);
                PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                userEdit.password = Hasher.HashPassword(userEdit, userEdit.password);
                user.password = userEdit.password;
                _context.SaveChanges();
                ViewBag.EditSuccess = "You successfully edited user.";
                return RedirectToAction("ManageUsers");
            }
            ViewBag.EditUser = "You must be an admin to edit users.";
            return RedirectToAction("ManageUsers");
        }

        [HttpGet("ordermanage")]
        public IActionResult OrderView()
        {
            ViewBag.orders = _context.Orders
                .Include(y => y.Order_Products).ThenInclude(z => z.Product).ThenInclude(xx => xx.Prices)
                .Include(y => y.Order_Products).ThenInclude(z => z.Product).ThenInclude(xx => xx.product_img)
                .Include(y => y.User)
                .Include(y => y.BillingAddress)
                .ToList();
            return View("OrderManage");
        }

        [HttpPost("updateorderstatus")]
        public IActionResult UpdateOrderStatus(string order_status, int order)
        {
            Orders updateorder = _context.Orders.FirstOrDefault(x => x.id == order);
            updateorder.order_status = order_status;
            _context.SaveChanges();
            return RedirectToAction("OrderView");
        }
    }
}
