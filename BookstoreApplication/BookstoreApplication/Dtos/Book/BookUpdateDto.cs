using System.ComponentModel.DataAnnotations;

namespace BookstoreApplication.Dtos.Book
{
    public class BookUpdateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int PageCount { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        [Required]
        public string ISBN { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int AuthorId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PublisherId { get; set; }
    }
}
