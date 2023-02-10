using AutoMapper;
using BookStore.API.DBOperations;
using BookStore.API.Entities;

namespace BookStore.API.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Name == Model.Name);
            if (author != null)
                throw new InvalidOperationException("Yazar zaten mevcut.");

            author = _mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();

        }



    }

    public class CreateAuthorModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime PublisDate { get; set; }
    }
}
