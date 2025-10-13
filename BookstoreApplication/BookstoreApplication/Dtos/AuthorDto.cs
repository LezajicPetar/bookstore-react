using System.ComponentModel.DataAnnotations;

namespace BookstoreApplication.Dtos
{
    public class AuthorDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Biography { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
