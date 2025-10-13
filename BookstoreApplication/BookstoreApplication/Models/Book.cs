namespace BookstoreApplication.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PageCount { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; } = string.Empty;

        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
    }
}
