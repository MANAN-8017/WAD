using CE130_Lab8.Data;
using CE130_Lab8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CE130_Lab8.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context){
            _context = context;
        }
        public async Task<IActionResult> Index(){
            var books = await _context.Books.ToListAsync();
            return View(books);
        }
        public async Task<IActionResult> Details(int? id){
            if (id == null){
                return NotFound();
            }
            var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
            if (book == null){
                return NotFound();
            }
            return View(book);
        }
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book){
            if (ModelState.IsValid){
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        public async Task<IActionResult> Edit(int? id){
            if (id == null){
                return NotFound();
            }
            var book = await _context.Books.FindAsync(id);
            if (book == null){
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book){
            if (id != book.BookId){
                return NotFound();
            }
            if (ModelState.IsValid){
                _context.Books.Update(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        public async Task<IActionResult> Delete(int? id){
            if (id == null){
                return NotFound();
            }
            var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
            if (book == null){
                return NotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id){
            var book = await _context.Books.FindAsync(id);
            if (book != null){
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}