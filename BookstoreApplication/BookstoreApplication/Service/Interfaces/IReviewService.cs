using BookstoreApplication.Dtos;

namespace BookstoreApplication.Service.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDto> AddReviewAsync(ReviewDto dto);
        Task<List<ReviewDto>> GetReviewsAsync(int bookId);
    }
}
