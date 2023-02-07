using BookStore.API.Common;
using BookStore.API.DBOperations;

namespace BookStore.API.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDBContext _dbContext;

        public GetBookDetailQuery(BookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int BookId { get; set; }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (book == null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı");
            }
            BookDetailViewModel vm = new BookDetailViewModel();
            vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            return vm;
        }
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
