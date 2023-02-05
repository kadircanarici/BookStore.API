using BookStore.API.Common;
using BookStore.API.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDBContext _dbContext;
        public GetBooksQuery(BookStoreDBContext dbContext)
        {
            _dbContext = dbContext;

        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
             List<BooksViewModel> wm=new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                wm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    PageCount = book.PageCount
                });
            }
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