using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace BookstoreApplication.Dtos.Book
{
    public class BookCreateDto
    {
        [Required]
        [MaxLength(50)]
        public required string Title { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int PageCount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [Required]
        public required string ISBN { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int AuthorId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PublisherId { get; set; }
    }
}
