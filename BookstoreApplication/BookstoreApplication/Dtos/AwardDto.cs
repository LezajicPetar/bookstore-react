using BookstoreApplication.Models;

namespace BookstoreApplication.Dtos
{
    public class AwardDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StartYear { get; set; }

        public List<AuthorAward>? AuthorsAwards { get; set; }

    }
}
