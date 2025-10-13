using BookstoreApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace BookstoreApplication.Dtos
{
    public class AwardDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int StartYear { get; set; }

        public List<AuthorAward>? AuthorsAwards { get; set; }

    }
}
