using BookStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.DBOperations
{
    public class BookStoreDBContext:DbContext,IBookStoreDbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext>options):base(options)
        {

        }
        public DbSet<Book>Books { get; set; }
        public DbSet<Genre>Genres { get; set; }
        public DbSet<Author>Authors { get; set; }
    
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    
    }
}
