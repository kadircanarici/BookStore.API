using BookStore.API.DBOperations;

namespace BookStore.API.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }

        private readonly BookStoreDBContext _context;

        public DeleteGenreCommand(BookStoreDBContext context)
        {
            _context = context;
        }
    }
}
