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
        public async Task<ActionResult<List<Author>>> GetAllAsync()
        {
            return await _authorRepo.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetByIdAsync(int id)
        {
            var author = await _authorRepo.GetByIdAsync(id);

            return author is null ? NotFound() : author;
        }

        [HttpPost]
        public async Task<ActionResult<Author>> PostAsync([FromBody]Author author)
        {
            return author is null ? BadRequest() : await _authorRepo.CreateAsync(author);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> PutAsync(int id, [FromBody]Author author)
        {
            if (id != author.Id) return BadRequest();

            var updated = await _authorRepo.UpdateAsync(author);

            return updated is null ? NotFound() : updated;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deleted = await _authorRepo.DeleteAsync(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}
