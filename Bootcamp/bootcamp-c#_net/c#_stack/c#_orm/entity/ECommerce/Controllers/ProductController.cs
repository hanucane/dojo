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
    public class ProductController : Controller
    {
        private Store _context;
        public ProductController(Store context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/products/categories")]
        public IActionResult ProductsCategories()
        {
            return View("ProductCategory");
        }

        [HttpPost("addProduct")]
        public IActionResult CreateProduct(Products newProduct, ProductImgs newImg, Inventory newInventory)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                TempData["product_id"] = newProduct.id;
                TempData["image"] = newImg.img_url;
                TempData["inventory"] = newInventory.quantity_new;
                return RedirectToAction("CreateImage");

            }
            return View("Index");
        }

        [HttpGet("addImage")]
        public IActionResult CreateImage()
        {
            if(ModelState.IsValid)
            {
                ProductImgs image = new ProductImgs(){
                    img_url = (string)TempData["image"],
                    ProductsId = (int)TempData["product_id"]
                };
                _context.ProductImgs.Add(image);
                _context.SaveChanges();
                TempData["product_id"] = TempData["product_id"];
                TempData["inventory"] = TempData["inventory"];
                return RedirectToAction("CreateInventory");

            }
            return View("Index");
        }
        
        [HttpPost("addImg")]
        public IActionResult AddImage(ProductImgs newImg)
        {
            if(ModelState.IsValid)
            {
                _context.ProductImgs.Add(newImg);
                _context.SaveChanges();
                List<Products> product = _context.Products.Where(x => x.id == newImg.ProductsId)
                .Include(y => y.product_category).ThenInclude(z => z.Category)
                .Include(y => y.product_img)
                .Include(y => y.Prices)
                .Include(y => y.Inventory)
                .ToList();
                ViewBag.products = product;
                ViewBag.images = _context.Products.Where(x => x.id == newImg.ProductsId).Include(y => y.product_img).ToList();
                ViewBag.prices = _context.Products.Where(x => x.id == newImg.ProductsId).Include(y => y.Prices).ToList();
                ViewBag.inventory = _context.Products.Where(x => x.id == newImg.ProductsId).Include(y => y.Inventory).ToList();
                ViewBag.categories = _context.Products.Where(x => x.id == newImg.ProductsId).Include(y => y.product_category).ThenInclude(z => z.Category).ToList();
                ViewBag.all_categories = _context.Categories.ToList();
                return Redirect("products/"+newImg.ProductsId);
            }
            return View("Index");
        }

        [HttpGet("addInventory")]
        public IActionResult CreateInventory()
        {
            if(ModelState.IsValid)
            {
                Inventory NewInventory = new Inventory(){
                    quantity_new = (int)TempData["inventory"],
                    ProductsId = (int)TempData["product_id"]
                };
                _context.Inventory.Add(NewInventory);
                _context.SaveChanges();
                return Redirect("products/"+TempData["product_id"]);

            }
            return View("Index");
        }

        [HttpPost("addPrice")]
        public IActionResult CreatePrice(Prices newPrice)
        {
            if(ModelState.IsValid)
            {
                _context.Prices.Add(newPrice);
                _context.SaveChanges();
                List<Products> product = _context.Products.Where(x => x.id == newPrice.ProductsId)
                .Include(y => y.product_category).ThenInclude(z => z.Category)
                .Include(y => y.product_img)
                .Include(y => y.Prices)
                .Include(y => y.Inventory)
                .ToList();
                ViewBag.products = product;
                ViewBag.images = _context.Products.Where(x => x.id == newPrice.ProductsId).Include(y => y.product_img).ToList();
                ViewBag.prices = _context.Products.Where(x => x.id == newPrice.ProductsId).Include(y => y.Prices).ToList();
                ViewBag.inventory = _context.Products.Where(x => x.id == newPrice.ProductsId).Include(y => y.Inventory).ToList();
                ViewBag.categories = _context.Products.Where(x => x.id == newPrice.ProductsId).Include(y => y.product_category).ThenInclude(z => z.Category).ToList();
                ViewBag.all_categories = _context.Categories.ToList();
                return Redirect("products/"+newPrice.ProductsId);
            }
            return View("Index");
        }

        [HttpGet("products/{id}")]
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
            return View("ProductView");
        }

        [HttpGet("products/grid")]
        public IActionResult ProductList()
        {
            ViewBag.products = _context.Products.Include(x => x.Prices).Include(x => x.product_img).ToList();
            ViewBag.categories = _context.Categories.ToList();
            return View("ProductGrid");
        }

        [HttpPost("addCategory")]
        public IActionResult CreateCategory(Categories newCategory)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
                return Redirect("category/"+newCategory.id);
            }
            return View("Index");
        }

        [HttpPost("products/{product_id}/addCategory")]
        public IActionResult AddCategory(int product_id, int category_id)
        {
            if(ModelState.IsValid)
            {
                Product_Category newProdCat = new Product_Category(){
                    ProductsId = product_id,
                    CategoriesId = category_id
                };
                _context.Product_Category.Add(newProdCat);
                _context.SaveChanges();
                ViewBag.products = _context.Products.Where(x => x.id == product_id).ToList();
                ViewBag.images = _context.Products.Where(x => x.id == product_id).Include(y => y.product_img).ToList();
                ViewBag.prices = _context.Products.Where(x => x.id == product_id).Include(y => y.Prices).ToList();
                ViewBag.inventory = _context.Products.Where(x => x.id == product_id).Include(y => y.Inventory).ToList();
                ViewBag.categories = _context.Products.Where(x => x.id == product_id).Include(y => y.product_category).ThenInclude(z => z.Category).ToList();
                ViewBag.all_categories = _context.Categories.ToList();
                return View("ProductView");
            }
            return View("Index");
        }
        
        [HttpPost("products/addCategory/{category_id}")]
        public IActionResult AddCategory2(int product_id, int category_id)
        {
            if(ModelState.IsValid)
            {
                Product_Category newProdCat = new Product_Category(){
                    ProductsId = product_id,
                    CategoriesId = category_id
                };
                _context.Product_Category.Add(newProdCat);
                _context.SaveChanges();
                ViewBag.category = _context.Categories.Where(x => x.id == category_id).ToList();
                ViewBag.products = _context.Categories.Where(x => x.id == category_id).Include(y => y.product_category).ThenInclude(z => z.Product).ThenInclude(a => a.product_img).ToList();
                ViewBag.all_products = _context.Products.Include(x => x.product_category).ThenInclude(y => y.Category).ToList();

                return View("CategoryView");
            }
            return View("Index");
        }

        [HttpGet("product/{product_id}/remove/{merge_id}")]
        public IActionResult RemoveCategory(int product_id, int merge_id)
        {
            var prod_cat_table = _context.Product_Category.FirstOrDefault(x => x.id == merge_id);
            _context.Product_Category.Remove(prod_cat_table);
            _context.SaveChanges();
            ViewBag.products = _context.Products.Where(x => x.id == product_id).ToList();
            ViewBag.images = _context.Products.Where(x => x.id == product_id).Include(y => y.product_img).ToList();
            ViewBag.prices = _context.Products.Where(x => x.id == product_id).Include(y => y.Prices).ToList();
            ViewBag.inventory = _context.Products.Where(x => x.id == product_id).Include(y => y.Inventory).ToList();
            ViewBag.categories = _context.Products.Where(x => x.id == product_id).Include(y => y.product_category).ThenInclude(z => z.Category).ToList();
            ViewBag.all_categories = _context.Categories.ToList();
            return View("ProductView");
        }

        [HttpGet("category/{id}")]
        public IActionResult CategoryView(int id)
        {
            ViewBag.category = _context.Categories.Where(x => x.id == id).ToList();
            ViewBag.products = _context.Categories.Where(x => x.id == id).Include(y => y.product_category).ThenInclude(z => z.Product).ThenInclude(a => a.product_img).ToList();
            ViewBag.all_products = _context.Products.Include(x => x.product_category).ThenInclude(y => y.Category).ToList();
            
            return View("CategoryView");
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
