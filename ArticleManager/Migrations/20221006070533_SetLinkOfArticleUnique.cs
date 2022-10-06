using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleManager.Migrations
{
    public partial class SetLinkOfArticleUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Articles",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Link",
                table: "Articles",
                column: "Link",
                unique: true,
                filter: "[Link] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Articles_Link",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
