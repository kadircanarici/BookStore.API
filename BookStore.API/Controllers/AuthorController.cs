using AutoMapper;
using BookStore.API.Application.AuthorOperations.Commands.CreateAuthor;
using BookStore.API.Application.AuthorOperations.Commands.DeleteAuthor;
using BookStore.API.Application.AuthorOperations.Commands.UpdateAuthor;
using BookStore.API.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStore.API.Application.AuthorOperations.Queries.GetAuthors;
using BookStore.API.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAuthor()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var authors = query.Handle();
            return Ok(authors);
        }

        [HttpGet("id")]
        public ActionResult GetByIdAuthor(int id)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            query.AuthorId = id;

            GetAuthorDetailValidator validator = new GetAuthorDetailValidator();
            validator.ValidateAndThrow(query);

            var author = query.Handle();
            return Ok(author);
        }


        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel model)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = model;

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel model)
        {

            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorID = id;
            command.Model = model;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {

            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorID = id;

            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();

        }


    }
}
