using BookStore.API.BookOperations.CreateBook;
using BookStore.API.BookOperations.DeleteBook;
using BookStore.API.BookOperations.GetBookDetail;
using BookStore.API.BookOperations.GetBooks;
using BookStore.API.BookOperations.UpdateBook;
using BookStore.API.DBOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BookStore.API.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.API.BookOperations.UpdateBook.UpdateBookCommand;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDBContext _context;

        public BookController(BookStoreDBContext context)
        {
            _context = context;
        }

        private static List<Book> BookList = new List<Book>()
        {
            
        };
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                result=query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

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
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
