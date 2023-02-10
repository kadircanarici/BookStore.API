using AutoMapper;
using BookStore.API.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public AuthorDetailViewModel Model;
        public GetAuthorDetailQuery(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.Include(x => x.Book).SingleOrDefault(x => x.ID == AuthorId);

            if (author == null)
                throw new InvalidOperationException("Yazar Bulunamadı!");

            AuthorDetailViewModel model = _mapper.Map<AuthorDetailViewModel>(author);
            return model;
        }

    }


    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Book { get; set; }
    }
}
