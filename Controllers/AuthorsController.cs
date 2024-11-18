using library_sys.Dtos.AuthorDtos;
using library_sys.Repos.AuthorRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace library_sys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepo _repo;
        public AuthorsController(IAuthorRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var a = _repo.GetAll();
            if (a == null)
            {
                return NotFound();
            }
            return Ok(a);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var s = _repo.GetById(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }
        [HttpPost]
        public IActionResult AddAuthor(AuthorDtoToAdd author)
        {
            _repo.AddAuthorAll(author);
            return Created();
        }
        [HttpPut]
        public IActionResult UpdateAuthor(AuthorDtoToAdd author , int id)
        {
            _repo.UpdateAuthor(author, id);
            return Accepted();
        }
        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            _repo.DeleteAuthor(id);
            return NoContent();
        }
        [HttpPut("AuthorOnly")]
        public IActionResult UpdateAuthorOnly(AuthorDtoToUpdateAuthor author , int id)
        {
            _repo.UpdateAuthorOnly(author, id);
            return Accepted();
        }
    }
}
