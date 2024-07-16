using Microsoft.EntityFrameworkCore;
using WebApi.BookStore.Data.Model;

namespace WebApi.BookStore.Data.Context;

public class BookStoreDbContext:DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options){}
    
    public DbSet<Book> Books { get; set; }

    public DbSet<Genre> Genres { get; set; }
    
    public DbSet<Author> Authors { get; set; }
    
    public List<Book> GetBooksFromDatabase()
    {
        return Books.ToList();
    }
}