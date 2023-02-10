using AutoMapper;
using BookStore.API.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStore.API.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<AuthorViewModel> Handle()
        {
            var author = _context.Authors.OrderBy(x => x.ID).ToList();
            List<AuthorViewModel> values = _mapper.Map<List<AuthorViewModel>>(author);
            return values;
        }
    }

    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
