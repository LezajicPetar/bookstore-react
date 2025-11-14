using System.ComponentModel.DataAnnotations;

namespace BookstoreApplication.Dtos
{
    public class ReviewDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; } = string.Empty;
    }
}
