using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorRepository _authorRepo;

        public AuthorsController(AuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        [HttpGet]
        public ActionResult<List<Author>> GetAll()
        {
            return _authorRepo.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetById(int id)
        {
            var author = _authorRepo.GetById(id);

            return author is null ? NotFound() : author;
        }

        [HttpPost]
        public ActionResult<Author> Post([FromBody]Author author)
        {
            return author is null ? BadRequest() : _authorRepo.Create(author);
        }

        [HttpPut("{id}")]
        public ActionResult<Author> Put(int id, [FromBody]Author author)
        {
            if (id != author.Id) return BadRequest();

            var existingAuthor = _authorRepo.GetById(id);
            if (existingAuthor == null) return NotFound();

            _authorRepo.Update(author);
            
            return author;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleted = _authorRepo.Delete(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}
