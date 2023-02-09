using BookStore.API.DBOperations;

namespace BookStore.API.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly BookStoreDBContext _context;

        public UpdateGenreCommand(BookStoreDBContext context)
        {
            _context = context;
        }

        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
    
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
                throw new InvalidOperationException("Kitap Türü Bulunamadı!");

            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
                throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut.");

            genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
            genre.isActive= Model.isActive;
            _context.SaveChanges();
        }

    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool isActive { get; set; } = true;
    }
}
