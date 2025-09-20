using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _bookRepo;
        private readonly PublisherRepository _publisherRepo;
        private readonly AuthorRepository _authorRepo;

        public BooksController(BookRepository bRepo, PublisherRepository pRepo, AuthorRepository aRepo)
        {
            _bookRepo = bRepo;
            _authorRepo = aRepo;
            _publisherRepo = pRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllAsync()
        {
            return await _bookRepo.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetByIdAsync(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);

            return book is null ? NotFound() : book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostAsync(Book book)
        {
            var author = await _authorRepo.GetByIdAsync(book.AuthorId);
            if (author == null) return BadRequest();

            var publisher = await _publisherRepo.GetByIdAsync(book.PublisherId);
            if (publisher == null) return BadRequest("PUBLISHER");


            book.Author = author;
            book.Publisher = publisher;

            await _bookRepo.CreateAsync(book);
            return book;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> PutAsync(int id, [FromBody]Book book)
        {
            if (id != book.Id) return BadRequest();

            var author = await _authorRepo.GetByIdAsync(book.AuthorId);
            if (author == null) return BadRequest();

            var publisher = await _publisherRepo.GetByIdAsync(book.PublisherId);
            if (publisher == null) return BadRequest();

            book.Author = author;
            book.Publisher = publisher;

            var updatedBook = await _bookRepo.UpdateAsync(book);

            return updatedBook is null ? NotFound() : updatedBook;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deleted = await _bookRepo.DeleteAsync(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}
