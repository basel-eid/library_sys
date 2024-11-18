using System.ComponentModel.DataAnnotations;

namespace library_sys.Dtos.AuthorDtos
{
    public class AuthorDtoToUpdateAuthor
    {
        [Required]
        public string? Name { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
    }
}
