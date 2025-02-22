using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libraryapp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Books");
            migrationBuilder.Sql("DELETE FROM Users");
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword("password");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "user1", hashedPassword, "Customer" },
                    { 2, "user2", hashedPassword, "Customer" },
                    { 3, "user3", hashedPassword, "Customer" },
                    { 4, "user4", hashedPassword, "Customer" },
                    { 5, "user5", hashedPassword, "Customer" },
                    { 6, "user6", hashedPassword, "Customer" },
                    { 7, "user7", hashedPassword, "Customer" },
                    { 8, "user8", hashedPassword, "Customer" },
                    { 9, "user9", hashedPassword, "Customer" },
                    { 10, "user10", hashedPassword, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Title", "Author", "ISBN", "PublishedDate", "Genre" },
                values: new object[,]
                {
                    { 1, "Book 1", "Author 1", "1234567890123", new DateTime(2020, 1, 1), "Fiction" },
                    { 2, "Book 2", "Author 2", "1234567890124", new DateTime(2020, 1, 1), "Fiction" },
                    { 3, "Book 3", "Author 3", "1234567890125", new DateTime(2020, 1, 1), "Fiction" },
                    { 4, "Book 4", "Author 4", "1234567890126", new DateTime(2020, 1, 1), "Fiction" },
                    { 5, "Book 5", "Author 5", "1234567890127", new DateTime(2020, 1, 1), "Fiction" },
                    { 6, "Book 6", "Author 6", "1234567890128", new DateTime(2020, 1, 1), "Fiction" },
                    { 7, "Book 7", "Author 7", "1234567890129", new DateTime(2020, 1, 1), "Fiction" },
                    { 8, "Book 8", "Author 8", "1234567890130", new DateTime(2020, 1, 1), "Fiction" },
                    { 9, "Book 9", "Author 9", "1234567890131", new DateTime(2020, 1, 1), "Fiction" },
                    { 10, "Book 10", "Author 10", "1234567890132", new DateTime(2020, 1, 1), "Fiction" },
                    { 11, "Book 11", "Author 11", "1234567890133", new DateTime(2020, 1, 1), "Fiction" },
                    { 12, "Book 12", "Author 12", "1234567890134", new DateTime(2020, 1, 1), "Fiction" },
                    { 13, "Book 13", "Author 13", "1234567890135", new DateTime(2020, 1, 1), "Fiction" },
                    { 14, "Book 14", "Author 14", "1234567890136", new DateTime(2020, 1, 1), "Fiction" },
                    { 15, "Book 15", "Author 15", "1234567890137", new DateTime(2020, 1, 1), "Fiction" },
                    { 16, "Book 16", "Author 16", "1234567890138", new DateTime(2020, 1, 1), "Fiction" },
                    { 17, "Book 17", "Author 17", "1234567890139", new DateTime(2020, 1, 1), "Fiction" },
                    { 18, "Book 18", "Author 18", "1234567890140", new DateTime(2020, 1, 1), "Fiction" },
                    { 19, "Book 19", "Author 19", "1234567890141", new DateTime(2020, 1, 1), "Fiction" },
                    { 20, "Book 20", "Author 20", "1234567890142", new DateTime(2020, 1, 1), "Fiction" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
              migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        }
    }
}
