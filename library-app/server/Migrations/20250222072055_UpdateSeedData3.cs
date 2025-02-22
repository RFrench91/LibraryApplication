using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libraryapp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 1", "Fiction", "1234567890123", "Book 1" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 2", "Fiction", "1234567890124", "Book 2" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 3", "Fiction", "1234567890125", "Book 3" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 4", "Fiction", "1234567890126", "Book 4" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 5", "Fiction", "1234567890127", "Book 5" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 6", "Fiction", "1234567890128", "Book 6" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 7", "Fiction", "1234567890129", "Book 7" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 8", "Fiction", "1234567890130", "Book 8" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 9", "Fiction", "1234567890131", "Book 9" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 10", "Fiction", "1234567890132", "Book 10" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 11", "Fiction", "1234567890133", "Book 11" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 12", "Fiction", "1234567890134", "Book 12" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 13", "Fiction", "1234567890135", "Book 13" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 14", "Fiction", "1234567890136", "Book 14" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 15", "Fiction", "1234567890137", "Book 15" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 16", "Fiction", "1234567890138", "Book 16" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 17", "Fiction", "1234567890139", "Book 17" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 18", "Fiction", "1234567890140", "Book 18" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 19", "Fiction", "1234567890141", "Book 19" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Author 20", "Fiction", "1234567890142", "Book 20" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Role", "Username" },
                values: new object[] { "$2a$10$gMxTU/i6xUqH4VMblDEqROIhGuvxo..jtx8zQ1vWgzfoxtE3tIDo.", "Librarian", "user1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Username" },
                values: new object[] { "$2a$10$slTluR99Da/WQSfa.MgS8..dv/78t6xBfUoyvr0TaZhAAOCpSJaA6", "user2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Role", "Username" },
                values: new object[] { "$2a$10$P1A3rkmkgNcGE/0XdI38lOlNE.kOyIa66aUcDKpQGLhIcPtFHmVkm", "Customer", "user3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Username" },
                values: new object[] { "$2a$10$UDTCgCaHYKlsM15tgEhnYe8bq5pqzuNUTKrxG6h9j0p7oeXOjkc8O", "user4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Username" },
                values: new object[] { "$2a$10$CSdlGg45LncmJbkBhQ1S2uWpzWHIktEk.YcJgpm8j6.JS9yYHwiny", "user5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Username" },
                values: new object[] { "$2a$10$MamEMYuV10V7WDtFYpD.3egBPOmFB.pgokmy2YXip2YgfHhVXc8PW", "user6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Username" },
                values: new object[] { "$2a$10$xWspv6RpwSMYOlUq6EgTcu9FogWbNBTw1gZgxMKgh6pZ/VTTiohL6", "user7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Role", "Username" },
                values: new object[] { "$2a$10$KNN0UyozG3CWe9D8TZO/bOvdW91o7zYV4.fhcqcvimUgDVXkkRsXe", "Customer", "user8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Role", "Username" },
                values: new object[] { "$2a$10$whGSxEgewkU5HadAGtU98uC90akvMsryBzBP53BKRatdcrD.jjS86", "Customer", "user9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Role", "Username" },
                values: new object[] { "$2a$10$ne5VqR6DBOjt/VozxzwhduH0m5OxzWa/z2K0hp8nCi3TWj8ja6cNC", "Customer", "user10" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Shyann Jerde", "Grocery", "0439446488057", "Fuga laudantium aliquid." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Humberto Toy", "Baby", "3279093133750", "Illum et dicta." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Nels Ryan", "Computers", "2731975560920", "Porro minus minus." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Chelsea Blick", "Kids", "4801014807786", "Ratione consequuntur est." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Lesly Torphy", "Toys", "2492160285331", "Voluptas et ad." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Dawson Wisoky", "Industrial", "3999166201710", "Ut non alias." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Jules Donnelly", "Garden", "0342585433591", "Qui quasi minus." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Angeline Lebsack", "Baby", "0649221924094", "Autem laudantium ea." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Zella Nienow", "Automotive", "4254982585512", "Enim dolores quia." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Torrey Jacobson", "Tools", "9610330476331", "Qui et aut." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Kaci Torphy", "Clothing", "0248892824582", "Ab voluptate beatae." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Delfina Trantow", "Grocery", "1627765337111", "Enim cumque vero." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Rhianna Runte", "Electronics", "5940242217079", "Illum sint velit." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Dewayne Welch", "Garden", "0082067428478", "Velit doloribus occaecati." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Kira Mraz", "Jewelery", "0531136750120", "Praesentium officiis corporis." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Shirley Cremin", "Home", "8062526034640", "Ullam deleniti ratione." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Rosalinda Weimann", "Automotive", "3391305774817", "Minima aut rem." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Berta Leuschke", "Automotive", "2101435610753", "Fuga quaerat inventore." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Annabell Satterfield", "Computers", "3253488944824", "Qui reiciendis rerum." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Author", "Genre", "ISBN", "Title" },
                values: new object[] { "Ewell Block", "Sports", "6626278907274", "Et officia vitae." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Role", "Username" },
                values: new object[] { "$2a$10$F8wrA5fFQ91ce3n5g6m/3ea73HYWTD6lGJVVgqpOLbiqIaqhRL6Im", "Customer", "Shaina.Welch" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Username" },
                values: new object[] { "$2a$10$0ZkdH0b79at7hZAmMPFNQuwNk.Az2Xpg79s74m80/Gl.KbfmHM/Te", "Antwan_Tremblay" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Role", "Username" },
                values: new object[] { "$2a$10$fLvz0DYen2ABrFArlc3wx.DZMZ.khxedQytdxFk4z.l.l7BDXEvba", "Librarian", "Margret.Reilly36" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Username" },
                values: new object[] { "$2a$10$WRlEeyUrYEFrwZ3gWnYIz.6wW5H8wF7dVJirf/iUb5QbfX0ejDtim", "Nyah_McKenzie75" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Username" },
                values: new object[] { "$2a$10$1N78WSHudfOh2poGEb2/7OyubNcv8Qgr.JOS5fQhzulBbWfRnP7hy", "Violette45" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Username" },
                values: new object[] { "$2a$10$ZqQkCsOi8sYxEl6liMzeUO16rqRrTKlbrK2kznWkxX5qwVrjaJ75e", "Micah.Braun" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Username" },
                values: new object[] { "$2a$10$h15KBy0pVS6a9qNrLDbPeuXWkT97XRqC5U/8KskSmqsfbG.iVdiVe", "Claude.Green" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Role", "Username" },
                values: new object[] { "$2a$10$nQ9v72O0mFcQ2u.L.vJm2.AHxD/t.h.ML9pRo.HnrzXfEKsunUMUW", "Librarian", "Moses.Rempel" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Role", "Username" },
                values: new object[] { "$2a$10$0DZiOXak0YWePsbUWsuJLuwKGnOPaNUxbcrTODxdyYN0qKvp0SjM6", "Librarian", "Gavin.Trantow26" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Role", "Username" },
                values: new object[] { "$2a$10$PJuejy1UVbirhNTgkowJcunOhRokLgfSr5ddBw6kdii6dF/lkbwc.", "Librarian", "Al.Beier42" });
        }
    }
}
