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
            return Ok(await _authorService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetByIdAsync(int id)
        {
            return  Ok(await _authorService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Author>> CreateAsync([FromBody]AuthorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _authorService.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> EditAsync(int id, [FromBody] AuthorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _authorService.UpdateAsync(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _authorService.DeleteAsync(id);

            return NoContent();
        }
    }
}
