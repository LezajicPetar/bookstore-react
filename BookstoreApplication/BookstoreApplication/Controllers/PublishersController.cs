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
        private readonly ILogger<PublishersController> _logger;

        public PublishersController(IPublisherService publisherService, ILogger<PublishersController> logger)
        {
            _publisherService = publisherService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetAllAsync()
        {
            _logger.LogInformation("HTTP GET /api/publishers triggered.");

            var publishers = await _publisherService.GetAllAsync();

            _logger.LogInformation("HTTP GET /api/publishers completed.");

            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetByIdAsync(int id)
        {
            _logger.LogInformation("HTTP GET /api/publishers/{PublisherId} triggered.", id);

            var publisher = await _publisherService.GetByIdAsync(id);

            _logger.LogInformation("HTTP GET /api/publishers/{PublisherId} completed.", id);

            return Ok(publisher);
        }

        [HttpPost]
        public async Task<ActionResult<Publisher>> CreateAsync([FromBody] PublisherDto dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state in POST /api/publishers");
                return BadRequest(ModelState);
            }

            _logger.LogInformation("HTTP POST /api/publishers triggered.");

            var publisher = await _publisherService.CreateAsync(dto);

            _logger.LogInformation("HTTP POST /api/publishers completed.");

            return Ok(publisher);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Publisher>> EditAsync(int id, [FromBody] PublisherDto dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state in PUT /api/publishers/{PublisherId}", id);
                return BadRequest(ModelState);
            }

            _logger.LogInformation("HTTP PUT api/publishers/{PublisherId} triggered.", id);

            var updated = await _publisherService.UpdateAsync(id, dto);

            _logger.LogInformation("HTTP PUT api/publishers/{PublisherId} completed.", id);

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            _logger.LogInformation("HTTP DELETE api/publishers/{PublisherId} triggered.", id);

            await _publisherService.DeleteAsync(id);

            _logger.LogInformation("HTTP DELETE api/publishers/{PublisherId} completed.", id);

            return NoContent();
        }
    }
}