using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [StringLength(60, ErrorMessage = "Author name cannot exceed 60 characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters")]
        public string Category { get; set; }

        [Range(1, 5000, ErrorMessage = "Price must be between 1₹ & 5000₹")]
        public double Price { get; set; }

        [Range(1500, 2100, ErrorMessage = "Published year must be realistic")]
        public int PublishedYear { get; set; }

        public Book() { }

        public Book(int bookId, string title, string author, string category, double price, int publishedYear)
        {
            this.BookId = bookId;
            this.Title = title;
            this.Author = author;
            this.Category = category;
            this.Price = price;
            this.PublishedYear = publishedYear;
        }
    }
}