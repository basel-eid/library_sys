using library_sys.Dtos.GenreDtos;
using library_sys.Models;
using System.ComponentModel.DataAnnotations;

namespace library_sys.Dtos.AuthorDtos
{
    public class AuthorDtoForBook
    {
        [Required]
        public string? Name { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        //public List<GenreDto>? Genres { get; set; }
    }
}
