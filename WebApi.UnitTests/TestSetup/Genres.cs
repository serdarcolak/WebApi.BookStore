using WebApi.BookStore.Data.Context;
using WebApi.BookStore.Data.Model;

namespace WebApi.UnitTests.TestSetup;

public static class Genres
{
    public static void AddGenres(this BookStoreDbContext context)
    {
        context.Genres.AddRange(
            new Genre { Name = "Personel Growth" },
            new Genre { Name = "Science Fiction" },
            new Genre { Name = "Romance" },
            new Genre { Name = "autobiography" }
            );
    }
}