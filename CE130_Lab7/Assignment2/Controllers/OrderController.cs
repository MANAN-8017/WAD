using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    public class OrderController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", Price = 55000 },
            new Product { ProductId = 2, ProductName = "Mobile Phone", Price = 25000 },
            new Product { ProductId = 3, ProductName = "Headphones", Price = 2000 }
        };

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Products = products;
            return View();
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel order)
        {
            if (!ModelState.IsValid){
                ViewBag.Products = products;
                return View(order);
            }
            return View("Success", order);
        }
    }
}
