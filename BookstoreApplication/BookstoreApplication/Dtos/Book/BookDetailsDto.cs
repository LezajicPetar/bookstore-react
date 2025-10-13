using System.ComponentModel.DataAnnotations;

namespace BookstoreApplication.Dtos.Book
{
    public class BookDetailsDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range (1, int.MaxValue)]
        public int PageCount { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }

        [Required]
        public string ISBN { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int AuthorId { get; set; }

        [Required]
        public string AuthorFullName { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int PublisherId { get; set; }

        [Required]
        public string PublisherName { get; set; } = string.Empty;
    }
}
