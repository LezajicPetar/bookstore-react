namespace BookstoreApplication.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public List<AuthorAward> ?AuthorsAwards { get; set; }
    }
}
