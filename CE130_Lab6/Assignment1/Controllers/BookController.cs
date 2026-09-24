using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using System.Linq;

namespace Assignment1.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>
        {
            new Book { BookId = 1, Title = "Clean Code", Author = "Robert C. Martin", Category = "Programming", Price = 500, PublishedYear = 2008 },
            new Book { BookId = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Category = "Programming", Price = 750, PublishedYear = 1999 }
        };


        static int BookId = 3;
        // GET: BookController
        public ActionResult Index()
        {
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            Book b = books.FirstOrDefault(book => book.BookId == id);
            return View(b);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                string Title = collection["Title"];
                string Author = collection["Author"];
                string Category = collection["Category"];
                string bookPrice = collection["Price"];
                string year = collection["PublishedYear"];

                if (!double.TryParse(bookPrice, out double Price))
                {
                    return BadRequest(new { Error = "Invalid Price format" });
                }

                if (!int.TryParse(year, out int PublishedYear))
                {
                    return BadRequest(new { Error = "Invalid Publish Year format" });
                }

                Book newBook = new Book(BookId, Title, Author, Category, Price, PublishedYear);
                BookId++;

                books.Add(newBook);

                Console.WriteLine("Added new book successfully");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            Book b = books.FirstOrDefault(book => book.BookId == id);
            return View(b);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                string bookPrice = collection["Price"];
                string year = collection["PublishedYear"];

                if (!double.TryParse(bookPrice, out double Price))
                {
                    return BadRequest(new { Error = "Invalid Price format" });
                }

                if (!int.TryParse(year, out int PublishedYear))
                {
                    return BadRequest(new { Error = "Invalid Publish Year format" });
                }

                Book b = books.FirstOrDefault(book => book.BookId == id);

                b.Title = collection["Title"];
                b.Author = collection["Author"];
                b.Category = collection["Category"];
                b.Price = Price;
                b.PublishedYear = PublishedYear;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            Book b = books.FirstOrDefault(book => book.BookId == id);
            return View(b);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                books.Remove(books.FirstOrDefault(book => book.BookId == id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
