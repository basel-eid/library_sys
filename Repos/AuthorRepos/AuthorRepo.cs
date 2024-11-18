using library_sys.Dtos.AuthorDtos;
using library_sys.Dtos.BookDtos;
using library_sys.Dtos.GenreDtos;
using library_sys.Models;
using Microsoft.EntityFrameworkCore;

namespace library_sys.Repos.AuthorRepos
{
    public class AuthorRepo : IAuthorRepo
    {
        public readonly DataContext _context;
        public AuthorRepo(DataContext context)
        {
            _context = context;
        }
        public void AddAuthorAll(AuthorDtoToAdd authorDtoToAdd)
        {
            var a = new Author
            {
                EmailAddress = authorDtoToAdd.EmailAddress,
                Name = authorDtoToAdd.Name,
                Phone = authorDtoToAdd.Phone,
                Books = authorDtoToAdd.BooksDtoForAuthor.Select(x => new Book
                {
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,
                    Genres = x.GenresDto.Select(x => new Genre
                    {
                        Name = x.Name,
                    }).ToList(),
                }).ToList(),
            };
            _context.Authors.Add(a);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var a = _context.Authors.Include(x=> x.Books).FirstOrDefault(x=> x.Id == id);
            if (a != null)
            {
                _context.Authors.Remove(a);
                _context.SaveChanges();
            }
            return;
        }

        public IEnumerable<AuthorDtoToGet> GetAll()
        {
            var a = _context.Authors.Include(x=> x.Books).ThenInclude(x=> x.Genres).Select(x=> new AuthorDtoToGet
            {
                EmailAddress= x.EmailAddress,
                Name = x.Name,
                Phone = x.Phone,
                BooksDtoForAuthor = x.Books.Select(x => new BookDtoForAuthor
                {
                    PublishedDate = x.PublishedDate,
                    Title = x.Title,
                    GenresDto = x.Genres.Select(o=> new GenreDto
                    {
                        Name = o.Name,
                    }).ToList(),
                }).ToList(),
            }).ToList();
            return a;
        }

        public AuthorDtoToGet GetById(int id)
        {
            var a = _context.Authors.Include(x => x.Books).ThenInclude(b => b.Genres).FirstOrDefault(x => x.Id == id);

            if (a == null)
            {
                throw new KeyNotFoundException($"Author with ID {id} not found.");
            }

            return new AuthorDtoToGet
            {
                EmailAddress = a.EmailAddress,
                Name = a.Name,
                Phone = a.Phone,
                BooksDtoForAuthor = a.Books.Select(x => new BookDtoForAuthor
                {
                    PublishedDate = x.PublishedDate,
                    Title = x.Title,
                    GenresDto = x.Genres.Select(g => new GenreDto
                    {
                        Name = g.Name,
                    }).ToList(),
                }).ToList(),
            };
        }

        public void UpdateAuthor(AuthorDtoToAdd authorDtoToAdd, int id)
        {
            var a = _context.Authors.Include(x=> x.Books).ThenInclude(x=> x.Genres).FirstOrDefault(x=> x.Id == id);
            a.EmailAddress = authorDtoToAdd.EmailAddress;
            a.Phone = authorDtoToAdd.Phone;
            a.Name = authorDtoToAdd.Name;
            a.Books = authorDtoToAdd.BooksDtoForAuthor.Select(x=> new Book
            {
                PublishedDate= x.PublishedDate,
                Title = x.Title,
                Genres = x.GenresDto.Select(v=> new Genre
                { 
                    Name = v.Name,
                }).ToList()
            }).ToList();
            _context.Authors.Update(a);
            _context.SaveChanges();
        }

        public void UpdateAuthorOnly(AuthorDtoToUpdateAuthor authorDtoToUpdateAuthor, int id)
        {
            var a = _context.Authors.FirstOrDefault(x=> x.Id == id);
            a.EmailAddress = authorDtoToUpdateAuthor.EmailAddress;
            a.Name = authorDtoToUpdateAuthor.Name;
            a.Phone = authorDtoToUpdateAuthor.Phone;
            _context.Authors.Update(a);
            _context.SaveChanges();
        }
    }
}
