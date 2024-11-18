using library_sys.Dtos.AuthorDtos;

namespace library_sys.Repos.AuthorRepos
{
    public interface IAuthorRepo
    {
        IEnumerable<AuthorDtoToGet> GetAll();
        AuthorDtoToGet GetById(int id);
        void AddAuthorAll(AuthorDtoToAdd authorDtoToAdd);
        void UpdateAuthor(AuthorDtoToAdd authorDtoToAdd, int id);
        void UpdateAuthorOnly(AuthorDtoToUpdateAuthor authorDtoToUpdateAuthor , int id);
        void DeleteAuthor(int id);

    }
}
