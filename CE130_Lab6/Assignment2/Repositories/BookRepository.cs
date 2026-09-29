using Assignment2.Models;

namespace Assignment2.Repositories
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> books = new List<Book>
        {
            new Book { BookId = 1, Title = "Clean Code", Author = "Robert C. Martin", Category = "Programming", Price = 500, PublishedYear = 2008 },
            new Book { BookId = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Category = "Programming", Price = 600, PublishedYear = 1999 }
        };

        private int bookId = 3;
        public List<Book> GetAll()
        {
            return books;
        }

        public Book? GetById(int id)
        {
            return books.FirstOrDefault(b => b.BookId == id);
        }

        public void Add(string Title, string Author, string Category, double Price, int PublishedYear)
        {
            Book book = new Book(bookId, Title, Author, Category, Price, PublishedYear);
            books.Add(book);
            bookId++;
        }

        public void Update(int BookId, string Title, string Author, string Category, double Price, int PublishedYear)
        {
            Book? existingBook = books.FirstOrDefault(b => b.BookId == BookId);

            if (existingBook != null)
            {
                existingBook.Title = Title;
                existingBook.Author = Author;
                existingBook.Category = Category;
                existingBook.Price = Price;
                existingBook.PublishedYear = PublishedYear;
            }
        }

        public void Delete(int id)
        {
            Book? book = books.FirstOrDefault(b => b.BookId == id);

            if (book != null)
            {
                books.Remove(book);
            }
        }
    }
}