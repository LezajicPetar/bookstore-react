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
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(IAuthorService authorService, ILogger<AuthorsController> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAsync()
        {
            _logger.LogInformation("HTTP GET /api/authors triggered.");

            var authors = await _authorService.GetAllAsync();

            _logger.LogInformation("HTTP GET /api/authors completed.");

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetByIdAsync(int id)
        {
            _logger.LogInformation("HTTP GET /api/authors/{AuthorId} triggered.", id);

            var author = await _authorService.GetByIdAsync(id);

            _logger.LogInformation("HTTP GET /api/authors/{AuthorId} completed.", id);

            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> CreateAsync([FromBody]AuthorDto dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state in POST /api/authors");
                return BadRequest(ModelState);
            }

            _logger.LogInformation("HTTP POST /api/authors triggered.");

            var author = await _authorService.CreateAsync(dto);

            _logger.LogInformation("HTTP POST /api/authors completed.");

            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> UpdateAsync(int id, [FromBody] AuthorDto dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state in PUT /api/authors/{AuthorId}", id);
                return BadRequest(ModelState);
            }

            _logger.LogInformation("HTTP PUT api/authors/{AuthorId} triggered.", id);

            var updated = await _authorService.UpdateAsync(id, dto);

            _logger.LogInformation("HTTP PUT api/authors/{AuthorId} completed.", id);

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            _logger.LogInformation("HTTP DELETE api/authors/{AuthorId} triggered.", id);

            await _authorService.DeleteAsync(id);

            _logger.LogInformation("HTTP DELETE api/authors/{AuthorId} completed.", id);

            return NoContent();
        }
    }
}
