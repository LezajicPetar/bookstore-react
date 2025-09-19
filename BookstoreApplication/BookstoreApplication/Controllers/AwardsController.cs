using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardsController : ControllerBase
    {
        private readonly AwardRepository _awardRepo;

        public AwardsController(AwardRepository awardRepo)
        {
            _awardRepo = awardRepo;
        }

        [HttpGet]
        public ActionResult<List<Award>> GetAll()
        {
            return Ok(_awardRepo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Award> GetById(int id)
        {
            var author = _awardRepo.GetById(id);

            return author is null ? NotFound() : Ok(author);
        }

        [HttpPost]
        public ActionResult<Award> Post([FromBody] Award award)
        {
            return award is null ? BadRequest() : Ok(_awardRepo.Create(award));
        }

        [HttpPut]
        public ActionResult<Award> Put(int id, [FromBody] Award award)
        {
            if (id != award.Id) return BadRequest();

            var existingAward = _awardRepo.GetById(id);
            if (existingAward is null) return NotFound();

            return Ok(_awardRepo.Update(award));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleted = _awardRepo.Delete(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}
