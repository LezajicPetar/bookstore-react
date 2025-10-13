using System.ComponentModel.DataAnnotations;

namespace BookstoreApplication.Dtos
{
    public class PublisherDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string Website { get; set; } = string.Empty;

    }
}
