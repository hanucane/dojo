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
    public class CustomerController : Controller
    {
        private Customer _context;
        public CustomerController(Customer context)
        {
            _context = context;
        }

        [HttpGet("registration")]
        public IActionResult Registration()
        {
            return View("Forms/Register");
        }

        [HttpPost("register")]
        public IActionResult Process(Users NewUser, string confirm_password)
        {
            if(ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(x => x.email == NewUser.email);
                if (user == null){
                    if (NewUser.password == confirm_password){
                        PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                        NewUser.password = Hasher.HashPassword(NewUser, NewUser.password);
                        _context.Users.Add(NewUser);
                        _context.SaveChanges();
                        HttpContext.Session.SetInt32("user", NewUser.id);
                        HttpContext.Session.SetInt32("user_level", NewUser.user_level);
                        HttpContext.Session.SetString("user_name", NewUser.first_name+" "+NewUser.last_name);
                        return Redirect("/");
                    }
                    ModelState.AddModelError("password", "Passwords must match.");
                }
                ModelState.AddModelError("email", "User with email already exists.");
            }
            return View("Forms/Register");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View("Forms/Login");
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string Password)
        {
            var user = _context.Users.FirstOrDefault(x => x.email == email);
            if(user != null && Password != null)
            {
                var Hasher = new PasswordHasher<Users>();
                if(0 != Hasher.VerifyHashedPassword(user, user.password, Password))
                {
                    HttpContext.Session.SetInt32("user", user.id);
                    HttpContext.Session.SetInt32("user_level", user.user_level);
                    HttpContext.Session.SetString("user_name", user.first_name+" "+user.last_name);
                    ViewBag.login="You successfully logged in.";
                    return Redirect("/");
                }
            }
            ViewBag.login="Please try logging in again.";
            return View("Forms/Login");
        }

        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
        
        [HttpGet("products/overview")]
        public IActionResult ProductList()
        {
            ViewBag.products = _context.Products.Include(x => x.Prices).Include(x => x.product_img).Include(x => x.Inventory).ToList();
            ViewBag.categories = _context.Categories.ToList();
            ViewBag.bestseller = _context.Inventory.OrderByDescending(x => x.quantity_sold)
                .Include(y => y.Product).ThenInclude(z => z.product_img)
                .Include(y => y.Product).ThenInclude(z => z.product_category).ThenInclude(xx => xx.Category)
                .Take(3).ToList();
            return View("ProductGrid");
        }

        [HttpGet("cart")]
        public IActionResult Cart()
        {
            ViewBag.cart = _context.Cart.Where(x => x.UsersId == HttpContext.Session.GetInt32("user"))
                .Include(y => y.Product).ThenInclude(z => z.Prices)
                .Include(y => y.Product).ThenInclude(z => z.product_img).ToList();
            ViewBag.cost = 0;
            foreach (var item in ViewBag.cart){
                ViewBag.cost += item.cost;
            }
            return View("Cart");
        }

        [HttpPost("addCart/{id}")]
        public IActionResult AddCart(Cart newItem, int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.id == id);
            var price = _context.Prices.FirstOrDefault(x => x.ProductsId == id);
            int userId = (int)HttpContext.Session.GetInt32("user");
            decimal totalItem = (decimal)price.new_price*newItem.quantity;
            if(ModelState.IsValid)
            {
                Cart newCart = new Cart(){
                    ProductsId = (int)product.id,
                    UsersId = userId,
                    quantity = newItem.quantity,
                    cost = totalItem
                };
                _context.Cart.Add(newCart);
                _context.SaveChanges();
                return RedirectToAction("Cart");
            }
            return RedirectToAction("Cart");
        }

        [HttpGet("removeCart/{id}")]
        public IActionResult RemoveCart(int id)
        {
            var cartItem = _context.Cart.FirstOrDefault(x => x.id == id);
            _context.Cart.Remove(cartItem);
            _context.SaveChanges();

            return RedirectToAction("Cart");
        }

        [HttpGet("checkout")]
        public IActionResult Checkout()
        {
            ViewBag.cart = _context.Cart.Where(x => x.UsersId == HttpContext.Session.GetInt32("user"))
                .Include(y => y.Product).ThenInclude(z => z.Prices)
                .Include(y => y.Product).ThenInclude(z => z.product_img).ToList();
            ViewBag.cost = 0;
            foreach (var item in ViewBag.cart){
                ViewBag.cost += item.cost;
            }
            return View("Checkout");
        }

        [HttpPost("submitOrder")]
        public IActionResult SubmitOrder(BillingAddresses newBilling, ShippingAddresses newShipping, PaymentMethods newPayment, string month, string year)
        {
            var user = HttpContext.Session.GetInt32("user");
            var cart = _context.Cart.Where(x => x.UsersId == (int)user).Include(y => y.Product).ToList();
            string expiration = month+"/"+year;
            if(ModelState.IsValid)
            {
                _context.BillingAddresses.Add(newBilling);
                _context.ShippingAddresses.Add(newShipping);
                _context.SaveChanges();
                PaymentMethods newPay = new PaymentMethods(){
                    UsersId = (int)user,
                    BillingAddressesId = newBilling.id,
                    card_type = newPayment.card_type,
                    card_name = newPayment.card_name,
                    card_num = newPayment.card_num,
                    card_ccv = newPayment.card_ccv,
                    card_exp = expiration,
                    nickname = newPayment.nickname,
                };
                _context.PaymentMethods.Add(newPay);
                _context.SaveChanges();
                Orders newOrder = new Orders(){
                    UsersId = (int)user,
                    BillingAddressesId = newBilling.id,
                    ShippingAddressesId = newShipping.id,
                    PaymentMethodsId = newPay.id,
                    order_status = "Processing"
                };
                _context.Orders.Add(newOrder);
                _context.SaveChanges();
                foreach(var item in cart)
                {
                    Inventory updateInventory = _context.Inventory.FirstOrDefault(x => x.ProductsId == item.ProductsId);
                    Order_Products newItem = new Order_Products(){
                        OrdersId = newOrder.id,
                        ProductsId = item.ProductsId,
                        quantity = item.quantity,
                        cost = item.cost
                    };
                    updateInventory.quantity_new -= item.quantity;
                    updateInventory.quantity_sold += item.quantity;
                    _context.Order_Products.Add(newItem);
                    _context.Cart.Remove(item);
                    _context.SaveChanges();
                }
                return RedirectToAction("OrderView");
            }

            ViewBag.cart = _context.Cart.Where(x => x.UsersId == HttpContext.Session.GetInt32("user"))
                .Include(y => y.Product).ThenInclude(z => z.Prices)
                .Include(y => y.Product).ThenInclude(z => z.product_img).ToList();
            ViewBag.cost = 0;
            foreach (var item in ViewBag.cart){
                ViewBag.cost += item.cost;
            }
            return View("Checkout");
        }

        [HttpGet("orders")]
        public IActionResult OrderView()
        {
            ViewBag.orders = _context.Orders.Where(x => x.UsersId == HttpContext.Session.GetInt32("user"))
                .Include(y => y.Order_Products).ThenInclude(z => z.Product).ThenInclude(xx => xx.Prices)
                .Include(y => y.Order_Products).ThenInclude(z => z.Product).ThenInclude(xx => xx.product_img)
                .ToList();
            return View("OrderHistory");
        }

        [HttpGet("profile")]
        public IActionResult Profile()
        {
            int currentUser = (int)HttpContext.Session.GetInt32("user");
            int id = _context.Users.FirstOrDefault(x => x.id == currentUser).id;
            ViewBag.user = _context.Users.FirstOrDefault(x => x.id == id);
            return View("Profile");
        }

        [HttpGet("product/{id}")]
        public IActionResult ViewProduct(int id)
        {
            List<Products> product = _context.Products.Where(x => x.id == id)
                .Include(y => y.product_category).ThenInclude(z => z.Category)
                .Include(y => y.product_img)
                .Include(y => y.Prices)
                .Include(y => y.Inventory)
                .ToList();
            ViewBag.products = product;
            ViewBag.images = _context.Products.Where(x => x.id == id).Include(y => y.product_img).ToList();
            ViewBag.prices = _context.Prices.Where(x => x.ProductsId == id).ToList();
            ViewBag.inventory = _context.Products.Where(x => x.id == id).Include(y => y.Inventory).ToList();
            ViewBag.categories = _context.Products.Where(x => x.id == id).Include(y => y.product_category).ThenInclude(z => z.Category).ToList();
            ViewBag.all_categories = _context.Categories.ToList();
            return View("CustomerProduct");
        }
    }
}