using BookstoreApplication.Data;
using BookstoreApplication.Dtos.Book;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;
using BookstoreApplication.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllAsync()
        {
            _logger.LogInformation("HTTP GET /api/books triggered.");

            var books = await _bookService.GetAllAsync();

            _logger.LogInformation("HTTP GET /api/books completed.");

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsDto>> GetByIdAsync(int id)
        {
            _logger.LogInformation("HTTP GET /api/books/{BookId} triggered.", id);

            var book = await _bookService.GetByIdAsync(id);

            _logger.LogInformation("HTTP GET /api/books/{BookId} completed.", id);

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateAsync([FromBody]BookCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state in POST /api/books");
                return BadRequest(ModelState);
            }

            _logger.LogInformation("HTTP POST /api/books triggered.");

            var book = await _bookService.CreateAsync(dto);

            _logger.LogInformation("HTTP POST /api/books completed.");

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateAsync(int id, [FromBody]BookUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state in POST /api/books/{BookId}", id);
                return BadRequest(ModelState);
            }
            _logger.LogInformation("HTTP PUT /api/books/{BookId} triggered.", id);

            var updated = await _bookService.UpdateAsync(id, dto);

            _logger.LogInformation("HTTP PUT /api/books/{BookId} completed.", id);

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            _logger.LogInformation("HTTP DELETE api/books/{BookId} triggered.", id);

            await _bookService.DeleteAsync(id);

            _logger.LogInformation("HTTP DELETE api/books/{BookId} completed.", id);

            return NoContent();
        }
    }
}
