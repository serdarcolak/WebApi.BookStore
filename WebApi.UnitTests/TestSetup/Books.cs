using WebApi.BookStore.Data.Context;
using WebApi.BookStore.Data.Model;

namespace WebApi.UnitTests.TestSetup;

public static class Books
{
    public static void AddBooks(this BookStoreDbContext context)
    {
        context.Books.AddRange(
            new Book { Title = "Mona Lisa Overdrive", GenreId = 1, AuthorId = 1, PageCount = 360, PublishDate = new DateTime(1988, 06, 12) },
            new Book { Title = "Count Zero", GenreId = 1, AuthorId = 1, PageCount = 256, PublishDate = new DateTime(1986, 01, 14) },
            new Book { Title = "Neuromancer", GenreId = 1, AuthorId = 1, PageCount = 271, PublishDate = new DateTime(1984, 07, 01) },
            new Book { Title = "Sol Ayağım", GenreId = 4, AuthorId = 2, PageCount = 271, PublishDate = new DateTime(1984, 07, 01) });
    }
}