using library_sys.Dtos.BookDtos;
using System.ComponentModel.DataAnnotations;

namespace library_sys.Dtos.AuthorDtos
{
    public class AuthorDtoToGet
    {
        [Required]
        public string? Name { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }

        public List<BookDtoForAuthor>? BooksDtoForAuthor { get; set; }
    }
}
