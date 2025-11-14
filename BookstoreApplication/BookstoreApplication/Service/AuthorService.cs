using AutoMapper;
using BookstoreApplication.Dtos;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Models;
using BookstoreApplication.Models.Interfaces;
using BookstoreApplication.Repository;
using BookstoreApplication.Service.Interfaces;

namespace BookstoreApplication.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorService> _logger;
        private IUnitOfWork _unitOfWork;

        public AuthorService(
            IAuthorRepository authorRepo, 
            IMapper mapper, 
            ILogger<AuthorService> logger,
            IUnitOfWork unitOfWork)
        {
            _authorRepo = authorRepo;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all authors...");

            var authors = await _authorRepo.GetAllAsync();

            _logger.LogInformation("Fetched {Count} authors.", authors.Count());

            return authors;
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Fetching author with ID {AuthorId}", id);

            var author = await _authorRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Author", id);

            _logger.LogInformation("Author with ID {AuthorId} retrieved successfully.", id);

            return author;
        }

        public async Task<Author> CreateAsync(AuthorDto dto)
        {
            _logger.LogInformation("Creating new author: {FullName}", dto.FullName);

            var author = _mapper.Map<Author>(dto);
            Author created = null;

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                created = await _authorRepo.CreateAsync(author);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            _logger.LogInformation("Author created successfully with ID {AuthorId}", created.Id);

            return author;
        }

        public async Task<Author> UpdateAsync(int id, AuthorDto dto)
        {
            _logger.LogInformation("Updating author with ID {AuthorId}.", id);

            var author = await _authorRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Author", id);

            _mapper.Map(dto, author);

            Author updated = null;
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                updated = await _authorRepo.UpdateAsync(author);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }


            _logger.LogInformation("Author with ID {AuthorId} successfully updated.", id);

            return updated;
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("Attempting to delete author with ID {AuthorId}", id);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var deleted = await _authorRepo.DeleteAsync(id)
                    ?? throw new NotFoundException("Author", id);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            _logger.LogInformation("Author with ID {AuthorId} deleted successfully.", id);
        }
    }
}
