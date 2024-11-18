using library_sys.Dtos.BookDtos;

namespace library_sys.Repos.BookRepos
{
    public interface IBookRepo
    {
        IEnumerable<BookDtoToCreate> GetBooks();
        BookDtoToCreate GetById(int id);
        void AddBook(BookDtoToCreate book);
        void UpdateBook(BookDtoToCreate book , int id);
        void DeleteBook(int id);
        void AddBookOnly(BookDtoToCreateBookOnly book);
    }
}
