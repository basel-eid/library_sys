using System.ComponentModel.DataAnnotations;

namespace library_sys.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
