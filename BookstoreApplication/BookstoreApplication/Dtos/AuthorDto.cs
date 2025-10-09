namespace BookstoreApplication.Dtos
{
    public class AuthorDto
    {
        public required string FullName { get; set; }
        public required string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
