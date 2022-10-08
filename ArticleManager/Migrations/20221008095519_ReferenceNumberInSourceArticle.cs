using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleManager.Migrations
{
    public partial class ReferenceNumberInSourceArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReferenceNumberInSourceArticle",
                table: "ArticleArticles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceNumberInSourceArticle",
                table: "ArticleArticles");
        }
    }
}
