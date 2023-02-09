using AutoMapper;
using BookStore.API.Application.BookOperations.Commands.CreateBook;
using BookStore.API.Application.BookOperations.Commands.DeleteBook;
using BookStore.API.Application.BookOperations.Commands.UpdateBook;
using BookStore.API.Application.BookOperations.Queries.GetBookDetail;
using BookStore.API.Application.BookOperations.Queries.GetBooks;
using BookStore.API.DBOperations;
using BookStore.API.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BookStore.API.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static BookStore.API.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private static List<Book> BookList = new List<Book>()
        {
            
        };
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            //try
            //{
                GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result=query.Handle();
            //}
            //catch (Exception ex)
            //{

            //    return BadRequest(ex.Message);
            //}

            return Ok(result);
           
        }

        //[HttpGet]
        //public Book Get([FromQuery] string id)
        //{
        //    var book = BookList.Where(b => b.Id ==Convert.ToInt32(id)).SingleOrDefault();
        //    return book;
        //}

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            //try
            //{
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                //if(!result.IsValid)
                //    foreach (var item in result.Errors)
                //    {
                //        Console.WriteLine("Özellik "+item.PropertyName +"-Error Message"+item.ErrorMessage);
                //    }
                //else
                command.Handle();

            //}
            //catch(Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            //try
            //{
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updatedBook;

                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();
            //}
            //catch (Exception ex)
            //{

            //    return BadRequest(ex.Message);
            //}
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            //try
            //{
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();
            //}
            //catch (Exception ex)
            //{

            //    return BadRequest(ex.Message);
            //}
            return Ok();
        }
    }
}
