using AutoMapper;
using BookstoreApplication.Dtos.Book;
using BookstoreApplication.Models;
using BookstoreApplication.Repository;

namespace BookstoreApplication.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IPublisherRepository _publisherRepo;
        private readonly IAuthorRepository _authorRepo;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bRepo, IPublisherRepository pRepo, IAuthorRepository aRepo, IMapper mapper)
        {
            _bookRepo = bRepo;
            _publisherRepo = pRepo;
            _authorRepo = aRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _bookRepo.GetAllAsync();

            return books
                .Select(_mapper.Map<BookDto>)
                .ToList();
        }

        public async Task<BookDetailsDto?> GetByIdAsync(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);

            return _mapper.Map<BookDetailsDto>(book);
        }

        public async Task<Book> CreateAsync(BookCreateDto dto)
        {
            var author = await _authorRepo.GetByIdAsync(dto.AuthorId)
                ?? throw new InvalidOperationException($"Author with the ID: {dto.AuthorId} not found.");
            var publisher = await _publisherRepo.GetByIdAsync(dto.PublisherId)
                ?? throw new InvalidOperationException($"Publisher with the ID: {dto.PublisherId} not found.");

            var book = new Book
            {
                Title = dto.Title,
                PageCount = dto.PageCount,
                PublishedDate = dto.PublishedDate,
                ISBN = dto.ISBN,
                AuthorId = dto.AuthorId,
                Author = author,
                PublisherId = dto.PublisherId,
                Publisher = publisher
            };

            await _bookRepo.CreateAsync(book);
            return book;
        }

        public async Task<Book> UpdateAsync(int id, BookUpdateDto dto)
        {
            var book = await _bookRepo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Book with the ID: {id} not found.");

            var author = await _authorRepo.GetByIdAsync(dto.AuthorId)
                ?? throw new InvalidOperationException($"Author with the ID: {dto.AuthorId} not found.");

            var publisher = await _publisherRepo.GetByIdAsync(dto.PublisherId)
                ?? throw new InvalidOperationException($"Publisher with the ID: {dto.PublisherId} not found.");

            book.Title = dto.Title;
            book.PageCount = dto.PageCount;
            book.PublishedDate = dto.PublishedDate;
            book.ISBN = dto.ISBN;
            book.Author = author;
            book.Publisher = publisher;

            return await _bookRepo.UpdateAsync(book);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookRepo.DeleteAsync(id);
        }
    }
}
