using BookStore.API.DBOperations;

namespace BookStore.API.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorID { get; set; }
        public UpdateAuthorModel Model { get; set; }

        private readonly IBookStoreDbContext _context;

        public UpdateAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.ID == AuthorID);

            if (author == null)
                throw new InvalidOperationException("Yazar Bulunamadı!");

            author.BookId = Model.BookId != default ? Model.BookId : author.BookId;
            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.LastName = Model.LastName != default ? Model.LastName : author.LastName;

        }

    }

    public class UpdateAuthorModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

    }
}
