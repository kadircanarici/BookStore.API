using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; } = true;

    }
}
