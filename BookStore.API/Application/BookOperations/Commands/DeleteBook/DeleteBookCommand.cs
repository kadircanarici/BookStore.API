using BookStore.API.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        public readonly BookStoreDBContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(BookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {

            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book == null)
                throw new InvalidOperationException("Silinecek Kitap Bulunamadı");
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();


        }
    }
}
