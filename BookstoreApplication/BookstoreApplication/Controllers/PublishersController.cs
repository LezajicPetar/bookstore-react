using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {

        private readonly PublisherRepository _publisherRepo;

        public PublishersController(PublisherRepository publisherRepo)
        {
            _publisherRepo = publisherRepo;
        }

        [HttpGet]
        public ActionResult<List<Publisher>> GetAll()
        {
            return _publisherRepo.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Publisher> GetById(int id)
        {
            var publisher = _publisherRepo.GetById(id);

            return publisher is null ? NotFound() : publisher;
        }

        [HttpPost]
        public ActionResult<Publisher> Post([FromBody] Publisher publisher)
        {
            return publisher is null ? BadRequest() : _publisherRepo.Create(publisher);
        }

        [HttpPut("{id}")]
        public ActionResult<Publisher> Put(int id, [FromBody] Publisher publisher)
        {
            if (id != publisher.Id) return BadRequest();

            var existingPublisher = _publisherRepo.GetById(id);
            if (existingPublisher == null) return NotFound();

            _publisherRepo.Update(publisher);

            return publisher;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleted = _publisherRepo.Delete(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}
