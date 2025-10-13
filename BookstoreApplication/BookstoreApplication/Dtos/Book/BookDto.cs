using System.ComponentModel.DataAnnotations;

namespace BookstoreApplication.Dtos.Book
{
    public class BookDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string ISBN { get; set; } = string.Empty;

        [Required]
        public string AuthorFullName { get; set; } = string.Empty;

        [Required]
        public string PublisherName { get; set; } = string.Empty;

        [Required]
        public int AgeInYears { get; set; }
    }
}
