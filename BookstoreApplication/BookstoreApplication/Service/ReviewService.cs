using AutoMapper;
using BookstoreApplication.Dtos;
using BookstoreApplication.Models;
using BookstoreApplication.Models.Interfaces;
using BookstoreApplication.Service.Interfaces;
using System.Data;

namespace BookstoreApplication.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(
            IReviewRepository reviewRepo,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _reviewRepo = reviewRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReviewDto> AddReviewAsync(ReviewDto dto)
        {
            var review = _mapper.Map<Review>(dto);
            Review newReview = null;

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                newReview = await _reviewRepo.AddReviewAsync(review);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
            }

            return _mapper.Map<ReviewDto>(newReview);
        }

        public async Task<List<ReviewDto>> GetReviewsAsync(int bookId)
        {
            List<Review> reviews = await _reviewRepo.GetReviewsAsync(bookId);

            List<ReviewDto> reviewDtos = _mapper.Map<List<ReviewDto>>(reviews);

            return reviewDtos;
        }
    }
}
