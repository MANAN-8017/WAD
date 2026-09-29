using Assignment2.Models;

namespace Assignment2.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetAll();
        public Book? GetById(int id);
        public void Add(string Title, string Author, string Category, double Price, int PublishedYear);
        public void Update(int BookId, string Title, string Author, string Category, double Price, int PublishedYear);
        public void Delete(int id);
    }
}
