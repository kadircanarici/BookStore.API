using BookStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                new Genre
                {
                    Name = "Science Fiction"
                },
                new Genre
                {
                    Name = "Romance"
                }
                );
                context.Authors.AddRange(
                    new Author
                    {
                        Name = "AuthorName1",
                        LastName = "AuthorLastName1",
                        DateOfBirth = new DateTime(1996, 06, 07),
                        BookId = 1


                    },
                    new Author
                    {
                        Name = "AuthorName2",
                        LastName = "AuthorLastName2",
                        DateOfBirth = new DateTime(1997, 11, 24),
                        BookId = 2

                    },
                    new Author
                    {
                        Name = "AuthorName3",
                        LastName = "AuthorLastName3",
                        DateOfBirth = new DateTime(1998, 10, 24),
                        BookId = 3

                    }

                );

                context.Books.AddRange(
                    new Book
                    {
                        Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1, //Personal Growth
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Herland",
                        GenreId = 2, //Science Fiction
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Dune",
                        GenreId = 2, //Science Fiction
                        PageCount = 540,
                        PublishDate = new DateTime(2001, 12, 21)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
