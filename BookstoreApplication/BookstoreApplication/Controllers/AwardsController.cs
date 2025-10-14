using BookstoreApplication.Data;
using BookstoreApplication.Dtos;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;
using BookstoreApplication.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardsController : ControllerBase
    {
        private readonly IAwardService _awardService;
        private readonly ILogger<AwardsController> _logger;

        public AwardsController(IAwardService awardService, ILogger<AwardsController> logger)
        {
            _awardService = awardService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Award>>> GetAllAsync()
        {
            _logger.LogInformation("HTTP GET /api/awards triggered.");

            var award = await _awardService.GetAllAsync();

            _logger.LogInformation("HTTP GET /api/awards completed.");

            return Ok(award);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Award>> GetByIdAsync(int id)
        {
            _logger.LogInformation("HTTP GET /api/awards/{AwardId} triggered.", id);

            var award = await _awardService.GetByIdAsync(id);

            _logger.LogInformation("HTTP GET /api/awards/{AwardId} completed.", id);

            return Ok(award);
        }

        [HttpPost]
        public async Task<ActionResult<Award>> CreateAsync([FromBody] AwardDto dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state in POST /api/awards");
                return BadRequest(ModelState);
            }

            _logger.LogInformation("HTTP POST /api/awards triggered.");

            var award = await _awardService.CreateAsync(dto);

            _logger.LogInformation("HTTP POST /api/awards completed.");

            return Ok(award);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Award>> UpdateAsync(int id, [FromBody] AwardDto dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state in PUT /api/awards/{AwardId}", id);
                return BadRequest(ModelState);
            }

            _logger.LogInformation("HTTP PUT api/awards/{AwardId} triggered.", id);

            var updated = await _awardService.UpdateAsync(id, dto);

            _logger.LogInformation("HTTP PUT api/awards/{AwardId} completed.", id);

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            _logger.LogInformation("HTTP DELETE api/awards/{AwardId} triggered.", id);

            await _awardService.DeleteAsync(id);

            _logger.LogInformation("HTTP DELETE api/awards/{AwardId} completed.", id);

            return NoContent();
        }
    }
}
