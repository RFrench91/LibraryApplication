using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace libraryapp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genre", "ISBN", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Alejandra Swaniawski", "Tools", "3354225340401", new DateTime(2019, 7, 26, 4, 6, 11, 321, DateTimeKind.Local).AddTicks(3116), "Omnis nihil enim." },
                    { 2, "Victor Johnson", "Books", "1864899033827", new DateTime(2025, 2, 19, 6, 24, 46, 464, DateTimeKind.Local).AddTicks(3606), "Maxime laborum sed." },
                    { 3, "Amya Kutch", "Computers", "1578362355100", new DateTime(2016, 5, 7, 2, 35, 19, 515, DateTimeKind.Local).AddTicks(2020), "Qui quasi eos." },
                    { 4, "Dixie Rodriguez", "Outdoors", "6700362639552", new DateTime(2023, 5, 12, 0, 4, 44, 928, DateTimeKind.Local).AddTicks(6143), "Eos neque nesciunt." },
                    { 5, "Jeremie Heller", "Tools", "1197592108500", new DateTime(2020, 11, 20, 7, 7, 0, 989, DateTimeKind.Local).AddTicks(4972), "Quo dolorem quaerat." },
                    { 6, "Efrain Mayert", "Garden", "3936669577423", new DateTime(2015, 8, 30, 22, 43, 55, 357, DateTimeKind.Local).AddTicks(3776), "Perferendis sed laudantium." },
                    { 7, "Bulah Wyman", "Sports", "8950568190236", new DateTime(2023, 11, 7, 10, 46, 45, 498, DateTimeKind.Local).AddTicks(7520), "Repudiandae ipsam impedit." },
                    { 8, "Nicola Pacocha", "Grocery", "8867237083938", new DateTime(2022, 6, 10, 3, 59, 50, 176, DateTimeKind.Local).AddTicks(3633), "Aspernatur facere earum." },
                    { 9, "Caroline Bogisich", "Books", "3762037134697", new DateTime(2018, 5, 1, 11, 19, 18, 174, DateTimeKind.Local).AddTicks(9240), "Distinctio non molestias." },
                    { 10, "Ima Nikolaus", "Jewelery", "8779517082619", new DateTime(2018, 9, 2, 16, 12, 17, 650, DateTimeKind.Local).AddTicks(394), "Ut reprehenderit et." },
                    { 11, "Scottie Connelly", "Sports", "3577415978530", new DateTime(2023, 8, 24, 3, 21, 31, 239, DateTimeKind.Local).AddTicks(130), "Qui est facere." },
                    { 12, "Carolyne Donnelly", "Movies", "9470621603552", new DateTime(2017, 7, 11, 8, 49, 38, 751, DateTimeKind.Local).AddTicks(7854), "Nostrum reiciendis necessitatibus." },
                    { 13, "Jayne Schaden", "Industrial", "6779695229310", new DateTime(2017, 8, 13, 2, 38, 19, 969, DateTimeKind.Local).AddTicks(4362), "Aut quo fugit." },
                    { 14, "Holden Boyle", "Grocery", "8154294888034", new DateTime(2018, 11, 14, 18, 53, 44, 608, DateTimeKind.Local).AddTicks(6611), "Soluta veritatis culpa." },
                    { 15, "Kamren Schuppe", "Tools", "9887470588822", new DateTime(2018, 2, 14, 22, 3, 51, 795, DateTimeKind.Local).AddTicks(6005), "Fugiat quis harum." },
                    { 16, "Coty Hessel", "Health", "1635895288241", new DateTime(2021, 9, 10, 10, 14, 13, 467, DateTimeKind.Local).AddTicks(1908), "Qui dignissimos consequatur." },
                    { 17, "Zachariah Christiansen", "Jewelery", "4122862707661", new DateTime(2020, 12, 27, 13, 13, 49, 714, DateTimeKind.Local).AddTicks(4004), "Sunt laboriosam sit." },
                    { 18, "Daryl Wisoky", "Kids", "5315085883369", new DateTime(2022, 6, 18, 11, 42, 27, 422, DateTimeKind.Local).AddTicks(467), "Accusamus et eaque." },
                    { 19, "Ana Kutch", "Music", "3144029929281", new DateTime(2024, 12, 8, 10, 16, 37, 261, DateTimeKind.Local).AddTicks(4974), "Dolor et delectus." },
                    { 20, "Loren Wilderman", "Jewelery", "6970676161043", new DateTime(2016, 4, 28, 16, 42, 6, 116, DateTimeKind.Local).AddTicks(8156), "Consectetur omnis quisquam." }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "$2a$10$TYxHp12gnslwIFe1NxydteuNlw1rsjglcnoz42NauiraTdVBdcBFu", "Librarian", "Keara65" },
                    { 2, "$2a$10$N.TDnOquiG/PwOmpegf2RO3ySe1s.9d0RUgNNFtJxOUDEjz4UxqZ.", "Librarian", "Sherwood_Simonis18" },
                    { 3, "$2a$10$qCNQG/vjmy.ZrweTSISfjus8ugyJNJxujlZliUp3OSRBCDkSOxqsu", "Librarian", "Elenora.Waters" },
                    { 4, "$2a$10$taPunFSURZQCXDBjf5x8.eeLN0X.g2JRAgBwQ.nDQoyfGiqnu/JbO", "Librarian", "Percy_Waters" },
                    { 5, "$2a$10$GnsjF.cCdpcwWIyySZRjYO.bwAQjXsU7gjVcmj.rvzNA.EJ0XEzMm", "Librarian", "Andreanne_Cassin" },
                    { 6, "$2a$10$jq3ZstOsYq.eDb9wCnTMYunhLTmZWLg8F1er4650MSc33tJI7QxtO", "Customer", "Angelina98" },
                    { 7, "$2a$10$ZQaAlkyVOs0PZN.h.KfRce./mQy8kmuZY87Aw5ixV7TvnwUZ00Ig6", "Librarian", "Jovani_Dach51" },
                    { 8, "$2a$10$IWrMxwFEWom/1wolmTVEPuK0DmSwD86ohFYxDZEeH2fNHXpfIhp62", "Customer", "Henry_Kuvalis2" },
                    { 9, "$2a$10$o7iWzDqiTEz5Q3LpvRcQ0OsRiIec5FmeN38HLFQk/CXNsKIstDMw.", "Customer", "Xzavier_Prohaska69" },
                    { 10, "$2a$10$K8vm.FYqN70aXjae/83gWuiu.Kqa6WC8y7WXHTSlZZTw/8QyjELrW", "Customer", "Wilfred.Spencer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
