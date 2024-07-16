using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.BookStore.Data.Context;
using WebApi.BookStore.Data.Model;

namespace WebApi.BookStore.Data.DataGenerator;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
        {
            if (context.Books.Any())
            {
                return; // data seeded
            }
            
            context.Genres.AddRange(
                new Genre
                {
                    Name = "Personel Growth"
                },
                new Genre
                {
                    Name = "Science Fiction"
                },
                new Genre
                {
                    Name = "Romance"
                },
                new Genre
                {
                    Name = "autobiography"
                }
                );

            context.Books.AddRange(
                new Book
                {
                    // Id = 1,
                    Title = "Mona Lisa Overdrive",
                    GenreId = 1, // Science Fiction
                    AuthorId = 1,
                    PageCount = 360,
                    PublishDate = new DateTime(1988, 06, 12)
                },
                new Book
                {
                    // Id = 2,
                    Title = "Count Zero",
                    GenreId = 1, // Sciance Fiction
                    AuthorId = 1,
                    PageCount = 256,
                    PublishDate = new DateTime(1986, 01, 14)
                },
                new Book
                {
                    // Id = 3,
                    Title = "Neuromancer",
                    GenreId = 1, // Sciance Fiction
                    AuthorId = 1,
                    PageCount = 271,
                    PublishDate = new DateTime(1984, 07, 01)
                },
                new Book
                {
                    // Id = 4,
                    Title = "Sol Ayağım",
                    GenreId = 4, // Sciance Fiction
                    AuthorId = 2,
                    PageCount = 271,
                    PublishDate = new DateTime(1984, 07, 01)
                }
            );
            
            context.Authors.AddRange(
                new Author
                {
                    // Id = 1,
                    Name = "William",
                    Surname = "Gibson",
                    Birthday = new DateTime(1948, 03, 17)
                },
                new Author
                {
                    // Id = 2,
                    Name = "Christy",
                    Surname = "Brown",
                    Birthday = new DateTime(1981, 09, 7)
                }
            );

            context.SaveChanges();
        }
    }
}