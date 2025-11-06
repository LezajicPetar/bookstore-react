using BookstoreApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Data
{
    public class LeafDbContext : IdentityDbContext<ApplicationUser>
    {
        public LeafDbContext(DbContextOptions<LeafDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<AuthorAward> AuthorsAwards { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                .Property(a => a.DateOfBirth)
                .HasColumnName("Birthday");

            modelBuilder.Entity<AuthorAward>()
                .ToTable("AuthorAwardBridge");

            modelBuilder.Entity<AuthorAward>()
                .HasOne(aa => aa.Award)
                .WithMany(a => a.AuthorsAwards)
                .HasForeignKey(aa => aa.AwardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AuthorAward>()
                .HasOne(aa => aa.Author)
                .WithMany(a => a.AuthorsAwards)
                .HasForeignKey(aa => aa.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany()
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);


            #region SEED DATA
            DateTime UtcDate(int year, int month, int day)
            {
                return new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc);
            }

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Penguin Books", Address = "80 Strand, London", Website = "https://penguin.co.uk" },
                new Publisher { Id = 2, Name = "Bloomsbury", Address = "50 Bedford Square, London", Website = "https://bloomsbury.com" },
                new Publisher { Id = 3, Name = "Vintage Books", Address = "New York, USA", Website = "https://vintagebooks.com" },
                new Publisher { Id = 4, Name = "HarperCollins", Address = "195 Broadway, New York", Website = "https://harpercollins.com" },
                new Publisher { Id = 5, Name = "Macmillan", Address = "120 Broadway, New York", Website = "https://macmillan.com" }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FullName = "George Orwell", Biography = "British writer and journalist.", DateOfBirth = UtcDate(1903, 6, 25) },
                new Author { Id = 2, FullName = "Jane Austen", Biography = "English novelist known for romantic fiction.", DateOfBirth = UtcDate(1775, 12, 16) },
                new Author { Id = 3, FullName = "J.K. Rowling", Biography = "British author best known for Harry Potter series.", DateOfBirth = UtcDate(1965, 7, 31) },
                new Author { Id = 4, FullName = "Mark Twain", Biography = "American writer and humorist.", DateOfBirth = UtcDate(1835, 11, 30) },
                new Author { Id = 5, FullName = "Leo Tolstoy", Biography = "Russian novelist, known for War and Peace.", DateOfBirth = UtcDate(1828, 9, 9) },
                new Author { Id = 6, FullName = "Ernest Hemingway", Biography = "American novelist, short-story writer, and journalist.", DateOfBirth = UtcDate(1899, 7, 21) },
                new Author { Id = 7, FullName = "Agatha Christie", Biography = "British writer known for detective novels.", DateOfBirth = UtcDate(1890, 9, 15) },
                new Author { Id = 8, FullName = "F. Scott Fitzgerald", Biography = "American novelist and short story writer.", DateOfBirth = UtcDate(1896, 9, 24) },
                new Author { Id = 9, FullName = "Charles Dickens", Biography = "English writer and social critic.", DateOfBirth = UtcDate(1812, 2, 7) },
                new Author { Id = 10, FullName = "Virginia Woolf", Biography = "English writer, pioneer of modernist literature.", DateOfBirth = UtcDate(1882, 1, 25) }
            );

            modelBuilder.Entity<Award>().HasData(
                new Award { Id = 1, Name = "Pulitzer Prize", Description = "Award for achievements in newspaper, magazine and online journalism.", StartYear = 1917 },
                new Award { Id = 2, Name = "Nobel Prize in Literature", Description = "Award for outstanding contributions in literature.", StartYear = 1901 },
                new Award { Id = 3, Name = "Booker Prize", Description = "Literary prize awarded each year for the best novel.", StartYear = 1969 },
                new Award { Id = 4, Name = "National Book Award", Description = "Annual U.S. literary award.", StartYear = 1950 },
                new Award { Id = 5, Name = "Hugo Award", Description = "Award for best science fiction or fantasy works.", StartYear = 1953 },
                new Award { Id = 6, Name = "Edgar Award", Description = "Award for best mystery fiction, non-fiction and television.", StartYear = 1946 },
                new Award { Id = 7, Name = "Women's Prize for Fiction", Description = "UK literary prize for best original full-length novel written by a woman.", StartYear = 1996 },
                new Award { Id = 8, Name = "Costa Book Award", Description = "Literary prize recognizing books by writers based in the UK and Ireland.", StartYear = 1971 }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", PageCount = 328, PublishedDate = UtcDate(1949, 6, 8), ISBN = "9780451524935", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 2, Title = "Animal Farm", PageCount = 112, PublishedDate = UtcDate(1945, 8, 17), ISBN = "9780451526342", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 3, Title = "Pride and Prejudice", PageCount = 432, PublishedDate = UtcDate(1813, 1, 28), ISBN = "9780141439518", AuthorId = 2, PublisherId = 3 },
                new Book { Id = 4, Title = "Emma", PageCount = 474, PublishedDate = UtcDate(1815, 12, 23), ISBN = "9780141439587", AuthorId = 2, PublisherId = 3 },
                new Book { Id = 5, Title = "Harry Potter and the Philosopher's Stone", PageCount = 223, PublishedDate = UtcDate(1997, 6, 26), ISBN = "9780747532699", AuthorId = 3, PublisherId = 2 },
                new Book { Id = 6, Title = "Harry Potter and the Chamber of Secrets", PageCount = 251, PublishedDate = UtcDate(1998, 7, 2), ISBN = "9780747538493", AuthorId = 3, PublisherId = 2 },
                new Book { Id = 7, Title = "The Old Man and the Sea", PageCount = 127, PublishedDate = UtcDate(1952, 9, 1), ISBN = "9780684801223", AuthorId = 6, PublisherId = 4 },
                new Book { Id = 8, Title = "Murder on the Orient Express", PageCount = 256, PublishedDate = UtcDate(1934, 1, 1), ISBN = "9780062073501", AuthorId = 7, PublisherId = 4 }
            );

            modelBuilder.Entity<AuthorAward>().HasData(
                new AuthorAward { Id = 1, AuthorId = 1, AwardId = 1 },
                new AuthorAward { Id = 2, AuthorId = 1, AwardId = 2 },
                new AuthorAward { Id = 3, AuthorId = 3, AwardId = 3 },
                new AuthorAward { Id = 4, AuthorId = 3, AwardId = 4 },
                new AuthorAward { Id = 5, AuthorId = 6, AwardId = 1 }
            );
            #endregion
        }
    }
}
