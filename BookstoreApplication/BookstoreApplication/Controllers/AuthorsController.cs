using BookstoreApplication.Data;
using BookstoreApplication.Dtos;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;
using BookstoreApplication.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAsync()
        {
            var authors = await _authorService.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetByIdAsync(int id)
        {
            var author = await _authorService.GetByIdAsync(id);

            return author is null ? NotFound() : author;
        }

        [HttpPost]
        public async Task<ActionResult<Author>> CreateAsync([FromBody]AuthorDto dto)
        {
            var author = await _authorService.CreateAsync(dto);

            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> EditAsync(int id, [FromBody] AuthorDto dto)
        {
            return await _authorService.UpdateAsync(id, dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deleted = await _authorService.DeleteAsync(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}
