using AutoMapper;
using BookstoreApplication.Dtos.Book;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookstoreApplication.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IPublisherRepository _publisherRepo;
        private readonly IAuthorRepository _authorRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;

        public BookService(
            IBookRepository bRepo, 
            IPublisherRepository pRepo, 
            IAuthorRepository aRepo, 
            IMapper mapper, 
            ILogger<BookService> logger)
        {
            _bookRepo = bRepo;
            _publisherRepo = pRepo;
            _authorRepo = aRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all books...");

            var books = await _bookRepo.GetAllAsync();

            _logger.LogDebug("Mapping {Count} books to DTOs...", books.Count());
            
            var bookDtos =  books
                .Select(_mapper.Map<BookDto>)
                .ToList();

            _logger.LogInformation("Returning {Count} mapped books.", bookDtos.Count);

            return bookDtos;
        }

        public async Task<BookDetailsDto?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Fetching book with ID {BookId}...", id);

            var book = await _bookRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Book", id);

            _logger.LogDebug("Mapping book to BookDetailsDto...");

            var bookDto = _mapper.Map<BookDetailsDto>(book);

            _logger.LogInformation("Book with ID {BookId} retrieved successfully.", id);

            return bookDto;
        }

        public async Task<Book> CreateAsync(BookCreateDto dto)
        {
            _logger.LogInformation("Creating new book: {Title}", dto.Title);

            var author = await _authorRepo.GetByIdAsync(dto.AuthorId)
                ?? throw new NotFoundException("Author", dto.AuthorId);
            var publisher = await _publisherRepo.GetByIdAsync(dto.PublisherId)
                ?? throw new NotFoundException("Publisher", dto.PublisherId);

            _logger.LogDebug("Mapping BookCreateDto to book.");

            var book = _mapper.Map<Book>(dto);

            book.Author = author;
            book.Publisher = publisher;

            var created = await _bookRepo.CreateAsync(book);

            _logger.LogInformation("Book created successfully with ID {BookId}", created.Id);

            return created;
        }

        public async Task<Book> UpdateAsync(int id, BookUpdateDto dto)
        {
            _logger.LogInformation("Updating book with ID {BookId}.", id);

            var book = await _bookRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Book", id);

            var author = await _authorRepo.GetByIdAsync(dto.AuthorId)
                ?? throw new NotFoundException("Author", dto.AuthorId);

            var publisher = await _publisherRepo.GetByIdAsync(dto.PublisherId)
                ?? throw new NotFoundException("Publisher", dto.PublisherId);

            _logger.LogDebug("Mapping BookUpdateDto to book");

            _mapper.Map(dto, book);

            book.Author = author;
            book.Publisher = publisher;

            var updated = await _bookRepo.UpdateAsync(book);

            _logger.LogInformation("Book with ID {BookId} successfully updated.", id);

            return updated;
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("Attempting to delete book with ID {BookId}", id);

            var deleted = await _bookRepo.DeleteAsync(id)
                ?? throw new NotFoundException("Book", id);

            _logger.LogInformation("Book with ID {BookId} deleted successfully.", id);
        }
    }
}
