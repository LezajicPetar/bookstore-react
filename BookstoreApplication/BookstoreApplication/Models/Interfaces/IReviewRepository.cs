using BookstoreApplication.Dtos;
using BookstoreApplication.Models;

namespace BookstoreApplication.Models.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetReviewsAsync(int bookId);
        Task<Review> AddReviewAsync(Review review);

    }
}
