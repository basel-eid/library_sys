using library_sys.Dtos.AuthorDtos;
using library_sys.Dtos.GenreDtos;

namespace library_sys.Dtos.BookDtos
{
    public class BookDtoToCreate
    {
        public string? Title { get; set; }
        public DateTime? Publishdate { get; set; }
        public List<AuthorDtoForBook>? AuthorDtoForBooks { get; set; }
        public List<GenreDto> Genres { get; set; }
    }
}
