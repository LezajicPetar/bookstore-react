using System.ComponentModel.DataAnnotations;

namespace BookstoreApplication.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
