using AutoMapper;
using BookStore.API.Common;
using BookStore.API.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.API.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public BookStoreDBContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreDBContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDB").Options;
            Context = new BookStoreDBContext(options);
            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); }).CreateMapper();

        }
    }
}
