using BookStore.API.DBOperations;
using BookStore.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.API.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDBContext context)
        {
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
                   });
        }
    }
}
