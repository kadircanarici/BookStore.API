using BookStore.API.DBOperations;

namespace BookStore.API.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorID { get; set; }
        private readonly IBookStoreDbContext _context;

        public DeleteAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author=_context.Authors.SingleOrDefault(x=>x.ID==AuthorID);

            if (author == null)
                throw new InvalidOperationException("Yazar bulunamadı.");

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
