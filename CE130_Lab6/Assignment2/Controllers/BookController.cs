using Microsoft.AspNetCore.Mvc;
using Assignment2.Repositories;

namespace Assignment2.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository repository;

        public BookController(IBookRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(repository.GetById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

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

                repository.Add(Title, Author, Category, Price, PublishedYear);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(repository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

                repository.Update(id, Title, Author, Category, Price, PublishedYear);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(repository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
