using CE130_Lab8.Models;
using Microsoft.EntityFrameworkCore;

namespace CE130_Lab8.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}