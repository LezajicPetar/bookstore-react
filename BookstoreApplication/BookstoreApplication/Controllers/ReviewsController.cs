using BookstoreApplication.Dtos;
using BookstoreApplication.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
             _reviewService = reviewService;
        }

        [HttpPost("{bookId}")]
        public async Task<IActionResult> AddReviewAsync([FromBody]ReviewDto dto)
        {
            var reviewDto = await _reviewService.AddReviewAsync(dto);
            return Ok(reviewDto);
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<List<ReviewDto>>> GetReviewsAsync(int bookId)
        {
            var reviews = await _reviewService.GetReviewsAsync(bookId);

            return Ok(reviews);
        }
    }
}
