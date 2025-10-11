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

        public AwardsController(IAwardService awardService)
        {
            _awardService = awardService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Award>>> GetAllAsync()
        {
            var awards = await _awardService.GetAllAsync();
            return Ok(awards);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Award>> GetByIdAsync(int id)
        {
            var award = await _awardService.GetByIdAsync(id);

            return award is null ? NotFound() : Ok(award);
        }

        [HttpPost]
        public async Task<ActionResult<Award>> CreateAsync([FromBody] AwardDto dto)
        {
            var award = await _awardService.CreateAsync(dto);

            return Ok(award);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Award>> EditAsync(int id, [FromBody] AwardDto dto)
        {
            return Ok(await _awardService.UpdateAsync(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deleted = await _awardService.DeleteAsync(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}
