using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookstoreApplication.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsAwards_Authors_AuthorId",
                table: "AuthorsAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsAwards_Awards_AwardId",
                table: "AuthorsAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorsAwards",
                table: "AuthorsAwards");

            migrationBuilder.RenameTable(
                name: "AuthorsAwards",
                newName: "AuthorAwardBridge");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorsAwards_AwardId",
                table: "AuthorAwardBridge",
                newName: "IX_AuthorAwardBridge_AwardId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorsAwards_AuthorId",
                table: "AuthorAwardBridge",
                newName: "IX_AuthorAwardBridge_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorAwardBridge",
                table: "AuthorAwardBridge",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "Birthday", "FullName" },
                values: new object[,]
                {
                    { 1, "British writer and journalist.", new DateTime(1903, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc), "George Orwell" },
                    { 2, "English novelist known for romantic fiction.", new DateTime(1775, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Jane Austen" },
                    { 3, "British author best known for Harry Potter series.", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc), "J.K. Rowling" },
                    { 4, "American writer and humorist.", new DateTime(1835, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Mark Twain" },
                    { 5, "Russian novelist, known for War and Peace.", new DateTime(1828, 9, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Leo Tolstoy" },
                    { 6, "American novelist, short-story writer, and journalist.", new DateTime(1899, 7, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Ernest Hemingway" },
                    { 7, "British writer known for detective novels.", new DateTime(1890, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Agatha Christie" },
                    { 8, "American novelist and short story writer.", new DateTime(1896, 9, 24, 0, 0, 0, 0, DateTimeKind.Utc), "F. Scott Fitzgerald" },
                    { 9, "English writer and social critic.", new DateTime(1812, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Charles Dickens" },
                    { 10, "English writer, pioneer of modernist literature.", new DateTime(1882, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Virginia Woolf" }
                });

            migrationBuilder.InsertData(
                table: "Awards",
                columns: new[] { "Id", "Description", "Name", "StartYear" },
                values: new object[,]
                {
                    { 1, "Award for achievements in newspaper, magazine and online journalism.", "Pulitzer Prize", 1917 },
                    { 2, "Award for outstanding contributions in literature.", "Nobel Prize in Literature", 1901 },
                    { 3, "Literary prize awarded each year for the best novel.", "Booker Prize", 1969 },
                    { 4, "Annual U.S. literary award.", "National Book Award", 1950 },
                    { 5, "Award for best science fiction or fantasy works.", "Hugo Award", 1953 },
                    { 6, "Award for best mystery fiction, non-fiction and television.", "Edgar Award", 1946 },
                    { 7, "UK literary prize for best original full-length novel written by a woman.", "Women's Prize for Fiction", 1996 },
                    { 8, "Literary prize recognizing books by writers based in the UK and Ireland.", "Costa Book Award", 1971 }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Address", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "80 Strand, London", "Penguin Books", "https://penguin.co.uk" },
                    { 2, "50 Bedford Square, London", "Bloomsbury", "https://bloomsbury.com" },
                    { 3, "New York, USA", "Vintage Books", "https://vintagebooks.com" },
                    { 4, "195 Broadway, New York", "HarperCollins", "https://harpercollins.com" },
                    { 5, "120 Broadway, New York", "Macmillan", "https://macmillan.com" }
                });

            migrationBuilder.InsertData(
                table: "AuthorAwardBridge",
                columns: new[] { "Id", "AuthorId", "AwardId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 3, 3 },
                    { 4, 3, 4 },
                    { 5, 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "ISBN", "PageCount", "PublishedDate", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "9780451524935", 328, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Utc), 1, "1984" },
                    { 2, 1, "9780451526342", 112, new DateTime(1945, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Animal Farm" },
                    { 3, 2, "9780141439518", 432, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Pride and Prejudice" },
                    { 4, 2, "9780141439587", 474, new DateTime(1815, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Emma" },
                    { 5, 3, "9780747532699", 223, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Harry Potter and the Philosopher's Stone" },
                    { 6, 3, "9780747538493", 251, new DateTime(1998, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Harry Potter and the Chamber of Secrets" },
                    { 7, 6, "9780684801223", 127, new DateTime(1952, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, "The Old Man and the Sea" },
                    { 8, 7, "9780062073501", 256, new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, "Murder on the Orient Express" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorAwardBridge_Authors_AuthorId",
                table: "AuthorAwardBridge",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorAwardBridge_Awards_AwardId",
                table: "AuthorAwardBridge",
                column: "AwardId",
                principalTable: "Awards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorAwardBridge_Authors_AuthorId",
                table: "AuthorAwardBridge");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorAwardBridge_Awards_AwardId",
                table: "AuthorAwardBridge");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorAwardBridge",
                table: "AuthorAwardBridge");

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "AuthorAwardBridge",
                newName: "AuthorsAwards");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorAwardBridge_AwardId",
                table: "AuthorsAwards",
                newName: "IX_AuthorsAwards_AwardId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorAwardBridge_AuthorId",
                table: "AuthorsAwards",
                newName: "IX_AuthorsAwards_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorsAwards",
                table: "AuthorsAwards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsAwards_Authors_AuthorId",
                table: "AuthorsAwards",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsAwards_Awards_AwardId",
                table: "AuthorsAwards",
                column: "AwardId",
                principalTable: "Awards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
