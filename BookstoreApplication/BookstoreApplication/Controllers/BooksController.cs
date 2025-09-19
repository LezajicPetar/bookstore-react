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
        public ActionResult<List<Book>> GetAll()
        {
            return _bookRepo.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            var book = _bookRepo.GetById(id);

            return book is null ? NotFound() : book;
        }

        [HttpPost]
        public ActionResult<Book> Post(Book book)
        {
            var author = _authorRepo.GetById(book.AuthorId);
            if (author == null) return BadRequest();

            var publisher = _publisherRepo.GetById(book.PublisherId);
            if (publisher == null) return BadRequest("PUBLISHER");


            book.Author = author;
            book.Publisher = publisher;

            _bookRepo.Create(book);
            return book;
        }

        [HttpPut("{id}")]
        public ActionResult<Book> Put(int id, [FromBody]Book book)
        {
            if (id != book.Id) return BadRequest();

            var author = _authorRepo.GetById(book.AuthorId);
            if (author == null) return BadRequest();

            var publisher = _publisherRepo.GetById(book.PublisherId);
            if (publisher == null) return BadRequest();

            book.Author = author;
            book.Publisher = publisher;

            var updatedBook = _bookRepo.Update(book);

            return updatedBook is null ? NotFound() : updatedBook;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleted = _bookRepo.Delete(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}
