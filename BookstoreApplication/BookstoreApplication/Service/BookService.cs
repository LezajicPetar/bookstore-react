using AutoMapper;
using BookstoreApplication.Dtos.Book;
using BookstoreApplication.Exceptions;
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
            var book = await _bookRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Book", id);

            return _mapper.Map<BookDetailsDto>(book);
        }

        public async Task<Book> CreateAsync(BookCreateDto dto)
        {
            var author = await _authorRepo.GetByIdAsync(dto.AuthorId)
                ?? throw new NotFoundException("Author", dto.AuthorId);
            var publisher = await _publisherRepo.GetByIdAsync(dto.PublisherId)
                ?? throw new NotFoundException("Publisher", dto.PublisherId);

            var book = _mapper.Map<Book>(dto);

            book.Author = author;
            book.Publisher = publisher;

            await _bookRepo.CreateAsync(book);
            return book;
        }

        public async Task<Book> UpdateAsync(int id, BookUpdateDto dto)
        {
            var book = await _bookRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Book", id);

            var author = await _authorRepo.GetByIdAsync(dto.AuthorId)
                ?? throw new NotFoundException("Author", dto.AuthorId);

            var publisher = await _publisherRepo.GetByIdAsync(dto.PublisherId)
                ?? throw new NotFoundException("Publisher", dto.PublisherId);

            _mapper.Map(dto, book);

            book.Author = author;
            book.Publisher = publisher;

            return await _bookRepo.UpdateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = await _bookRepo.DeleteAsync(id)
                ?? throw new NotFoundException("Book", id);
        }
    }
}
