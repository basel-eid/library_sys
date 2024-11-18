using library_sys.Dtos.AuthorDtos;
using library_sys.Dtos.BookDtos;
using library_sys.Repos.AuthorRepos;
using library_sys.Repos.BookRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace library_sys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo _repo;
        public BooksController(IBookRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAllBook()
        {
            var a = _repo.GetBooks();
            if (a == null)
            {
                return NotFound();
            }
            return Ok(a);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdBook(int id)
        {
            var s = _repo.GetById(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }
        [HttpPost]
        public IActionResult AddBook(BookDtoToCreate author)
        {
            _repo.AddBook(author);
            return Created();
        }
        [HttpPut]
        public IActionResult UpdateBookOnly(BookDtoToCreate author, int id)
        {
            _repo.UpdateBook(author, id);
            return Accepted();
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            _repo.DeleteBook(id);
            return NoContent();
        }
        [HttpPost("BookOnly")]
        public IActionResult UpdateBookOnly(BookDtoToCreateBookOnly author)
        {
            _repo.AddBookOnly(author);
            return Accepted();
        }
    }
}
