using BookstoreApplication.Data;
using BookstoreApplication.Dtos;
using BookstoreApplication.Models;
using BookstoreApplication.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly LeafDbContext _context;

        public ReviewRepository(LeafDbContext context)
        {
            _context = context;
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
                await _context.Reviews.AddAsync(review);
                return review;
        }

        public async Task<List<Review>> GetReviewsAsync(int bookId)
        {
            var data = await _context.Reviews
                .Where(r => r.BookId == bookId)
                .ToListAsync();

            return data;
        }
    }
}
