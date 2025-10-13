using BookstoreApplication.Data;
using BookstoreApplication.Dtos.Book;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;
using BookstoreApplication.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllAsync()
        {
            return Ok(await _bookService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsDto>> GetByIdAsync(int id)
        {
            return Ok(await _bookService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateAsync([FromBody]BookCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _bookService.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateAsync(int id, [FromBody]BookUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _bookService.UpdateAsync(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _bookService.DeleteAsync(id);

            return NoContent();
        }
    }
}
