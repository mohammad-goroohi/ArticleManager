using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleManager.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ArticleDescription = table.Column<string>(nullable: true),
                    MyDescription = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ArticleArticles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceArticleID = table.Column<int>(nullable: false),
                    DestinationArticleID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleArticles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArticleArticles_Articles_DestinationArticleID",
                        column: x => x.DestinationArticleID,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleArticles_Articles_SourceArticleID",
                        column: x => x.SourceArticleID,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleArticles_DestinationArticleID",
                table: "ArticleArticles",
                column: "DestinationArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleArticles_SourceArticleID",
                table: "ArticleArticles",
                column: "SourceArticleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleArticles");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
