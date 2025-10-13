using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Models
{
    public class Award
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StartYear { get; set; }

        public List<AuthorAward> ?AuthorsAwards { get; set; }
    }
}
