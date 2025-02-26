using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libraryapp.Migrations
{
    /// <inheritdoc />
    public partial class AddReviews2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Reviews",
                newName: "Comment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Reviews",
                newName: "Text");
        }
    }
}
