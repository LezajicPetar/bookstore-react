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
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllAsync()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetByIdAsync(int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            return book is null ? NotFound() : book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateAsync([FromBody]BookCreateDto dto)
        {
            var newBook = await _bookService.CreateAsync(dto);

            return newBook is null ? BadRequest("Author or Publisher not found.") : Ok(newBook);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateAsync(int id, [FromBody]BookUpdateDto dto)
        {
            var updatedBook = await _bookService.UpdateAsync(id, dto);

            return updatedBook is null ? BadRequest("Author or Publisher not found.") : updatedBook;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deleted = await _bookService.DeleteAsync(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}
