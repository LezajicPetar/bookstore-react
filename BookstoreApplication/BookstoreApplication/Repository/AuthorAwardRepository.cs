using BookstoreApplication.Data;

namespace BookstoreApplication.Repository
{
    public class AuthorAwardRepository
    {
        private readonly LeafDbContext _context;

        public AuthorAwardRepository(LeafDbContext context)
        {
            _context = context;
        }
    }
}
