using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleManager.Migrations
{
    public partial class addyearandcitationcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CitationCountInGoogleScholar",
                table: "Articles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublishedYear",
                table: "Articles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CitationCountInGoogleScholar",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "PublishedYear",
                table: "Articles");
        }
    }
}
