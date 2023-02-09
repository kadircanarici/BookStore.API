using AutoMapper;
using BookStore.API.Common;
using BookStore.API.DBOperations;
using BookStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.Include(x=>x.Genre).OrderBy(x => x.Id).ToList();
            List<BooksViewModel> wm = _mapper.Map<List<BooksViewModel>>(bookList);  //new List<BooksViewModel>();
            //foreach (var book in bookList)
            //{
            //    wm.Add(new BooksViewModel()
            //    {
            //        Title = book.Title,
            //        Genre = ((GenreEnum)book.GenreId).ToString(),
            //        PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
            //        PageCount = book.PageCount
            //    });
            //}
            return wm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}