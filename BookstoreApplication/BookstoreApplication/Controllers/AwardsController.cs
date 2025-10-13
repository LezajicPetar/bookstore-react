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
            return Ok(await _awardService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Award>> GetByIdAsync(int id)
        {
            return Ok(await _awardService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Award>> CreateAsync([FromBody] AwardDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _awardService.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Award>> EditAsync(int id, [FromBody] AwardDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _awardService.UpdateAsync(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _awardService.DeleteAsync(id);

            return NoContent();
        }
    }
}
