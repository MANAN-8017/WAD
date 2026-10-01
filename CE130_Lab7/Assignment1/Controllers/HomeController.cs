using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        private static List<Book> books = new List<Book>
        {
            new Book { BookId = 1, Title = "Clean Code", Author = "Robert C. Martin", Category = "Programming", Price = 599, PublishedYear = 1999 },
            new Book { BookId = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Category = "Programming", Price = 699, PublishedYear = 2002 },
            new Book { BookId = 3, Title = "Atomic Habits", Author = "James Clear", Category = "Self Help", Price = 499, PublishedYear = 2010 },
            new Book { BookId = 4, Title = "Rich Dad Poor Dad", Author = "Robert Kiyosaki", Category = "Finance", Price = 399, PublishedYear = 2012 }
        };

        public IActionResult Index()
        {
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Books()
        {
            return View(books);
        }

        public IActionResult Categories()
        {
            var categories = books
                .Select(b => b.Category)
                .Distinct()
                .ToList();

            return View(categories);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
