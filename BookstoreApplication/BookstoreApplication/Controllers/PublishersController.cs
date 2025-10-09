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
    public class PublishersController : ControllerBase
    {

        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetAllAsync()
        {
            var publishers = await _publisherService.GetAllAsync();
            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetByIdAsync(int id)
        {
            var publisher = await _publisherService.GetByIdAsync(id);

            return publisher is null ? NotFound() : publisher;
        }

        [HttpPost]
        public async Task<ActionResult<Publisher>> CreateAsync([FromBody] PublisherDto dto)
        {
            var publisher = await _publisherService.CreateAsync(dto);

            return Ok(publisher);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Publisher>> EditAsync(int id, [FromBody] PublisherDto dto)
        {
            return await _publisherService.UpdateAsync(id, dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deleted = await _publisherService.DeleteAsync(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}