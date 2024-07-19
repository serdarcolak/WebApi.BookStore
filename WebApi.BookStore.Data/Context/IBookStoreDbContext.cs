using Microsoft.EntityFrameworkCore;
using WebApi.BookStore.Data.Model;

namespace WebApi.BookStore.Data.Context;

public interface IBookStoreDbContext
{
    DbSet<Book> Books { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Author> Authors { get; set; }

    int SaveChanges();
}