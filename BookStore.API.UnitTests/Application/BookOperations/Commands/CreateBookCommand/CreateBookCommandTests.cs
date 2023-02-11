using AutoMapper;
using BookStore.API.DBOperations;
using BookStore.API.Entities;
using BookStore.API.UnitTests.TestSetup;

namespace BookStore.API.UnitTests.Application.BookOperations.Commands.CreateBookCommand
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange(hazırlık)
            var book = new Book()
            {
                Title = "WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",
                PageCount = 100,
                PublishDate = new System.DateTime(1990, 01, 10),
                GenreId = 1
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);


            //act(çalıştırma)
            //assert(dogrulama)

        }
    }
}
