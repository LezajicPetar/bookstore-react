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
        public async Task<ActionResult<List<Publisher>>> GetAllAsync()
        {
            return await _publisherRepo.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetByIdAsync(int id)
        {
            var publisher = await _publisherRepo.GetByIdAsync(id);

            return publisher is null ? NotFound() : publisher;
        }

        [HttpPost]
        public async Task<ActionResult<Publisher>> PostAsync([FromBody] Publisher publisher)
        {
            return publisher is null ? BadRequest() : await _publisherRepo.CreateAsync(publisher);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Publisher>> PutAsync(int id, [FromBody] Publisher publisher)
        {
            if (id != publisher.Id) return BadRequest();

            var updated = await _publisherRepo.UpdateAsync(publisher);

            return updated is null ? NotFound() : updated;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deleted =await _publisherRepo.DeleteAsync(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}
