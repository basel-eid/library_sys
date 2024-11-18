namespace library_sys.Dtos.BookDtos
{
    public class BookDtoToCreateBookOnly
    {
        public string? Title { get; set; }
        public DateTime? PublishedDate { get; set; }
        public List<int>? GenreId { get; set; }
        public List<int>? AuthorId { get; set; }
    }
}
