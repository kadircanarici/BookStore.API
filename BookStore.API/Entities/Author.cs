using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Entities
{
    public class Author
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
