using BookStore.API.DBOperations;
using BookStore.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.API.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDBContext context)
        {
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
        }
    }
}
