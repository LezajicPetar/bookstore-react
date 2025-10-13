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
            return Ok(await _publisherService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetByIdAsync(int id)
        {
            return Ok(_publisherService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Publisher>> CreateAsync([FromBody] PublisherDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _publisherService.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Publisher>> EditAsync(int id, [FromBody] PublisherDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _publisherService.UpdateAsync(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _publisherService.DeleteAsync(id);

            return NoContent();
        }
    }
}