using library_sys.Dtos.GenreDtos;
using System.ComponentModel.DataAnnotations;

namespace library_sys.Dtos.BookDtos
{
    public class BookDtoForAuthor
    {
        [Required(ErrorMessage = "The Title is required")]
        public string? Title { get; set; }
        public DateTime? PublishedDate { get; set; }
        public List<GenreDto>? GenresDto { get; set; }
    }
}
