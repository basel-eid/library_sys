using library_sys.Dtos.AuthorDtos;
using library_sys.Dtos.BookDtos;
using library_sys.Dtos.GenreDtos;
using library_sys.Models;
using Microsoft.EntityFrameworkCore;

namespace library_sys.Repos.BookRepos
{
    public class BookRepo : IBookRepo
    {
        private readonly DataContext _context;
        public BookRepo(DataContext context)
        {
            _context = context;
        }
        public void AddBook(BookDtoToCreate book)
        {
            var b = new Book
            {
                PublishedDate = book.Publishdate,
                Title = book.Title,
                Authors = book.AuthorDtoForBooks.Select(x => new Author
                {
                    Name = x.Name,
                    Phone = x.Phone,
                    EmailAddress = x.EmailAddress
                }).ToList(),
                Genres = book.AuthorDtoForBooks.Select(x => new Genre { Name = x.Name, }).ToList(),
            };
            _context.Books.Add(b);
            _context.SaveChanges();
        }

        public void AddBookOnly(BookDtoToCreateBookOnly book)
        {
            var b = new Book
            {
                PublishedDate = book.PublishedDate,
                Title = book.Title,
                Genres = _context.Genres.Where(x => book.GenreId.Contains(x.Id)).ToList(),
                Authors = _context.Authors.Where(x => book.AuthorId.Contains(x.Id)).ToList(),
            };
            _context.Books.Add(b);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var b = _context.Books.FirstOrDefault(x=> x.Id ==  id);
            if(b != null)
            {
                _context.Books.Remove(b);
                _context.SaveChanges();
            }
            return;
        }

        public IEnumerable<BookDtoToCreate> GetBooks()
        {
            var b = _context.Books.Include(x => x.Authors).Include(x => x.Genres).Select(x => new BookDtoToCreate
            {
                Publishdate = x.PublishedDate,
                Title = x.Title,
                AuthorDtoForBooks = x.Authors.Select(x => new AuthorDtoForBook
                {
                    Name = x.Name,
                    Phone = x.Phone,
                    EmailAddress = x.EmailAddress,

                }).ToList(),
                Genres = x.Genres.Select(x => new GenreDto {
                    Name = x.Name,
                }).ToList(),
            }).ToList();
            return b;
        }
        

        public BookDtoToCreate GetById(int id)
        {
            var b = _context.Books.Include(x => x.Authors).Include(x => x.Genres).FirstOrDefault(x=> x.Id == id);
            return new BookDtoToCreate
            {
                Title = b.Title,
                Publishdate = b.PublishedDate,
                AuthorDtoForBooks = b.Authors.Select(x => new AuthorDtoForBook { Name = x.Name, Phone = x.Phone, EmailAddress = x.EmailAddress, }).ToList(),
                Genres = b.Genres.Select(x => new GenreDto { Name = x.Name }).ToList(),
            };
        }

        public void UpdateBook(BookDtoToCreate book, int id)
        {
            var b = _context.Books.Include(x => x.Authors).Include(x => x.Genres).FirstOrDefault(x => x.Id == id);
            b.PublishedDate = book.Publishdate;
            b.Title = book.Title;
            
        }
    }
}
