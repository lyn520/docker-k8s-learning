using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore一对多.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Article",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Comment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    WithArticleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Comment_T_Article_WithArticleId",
                        column: x => x.WithArticleId,
                        principalTable: "T_Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Article_Title",
                table: "T_Article",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_Comment_WithArticleId",
                table: "T_Comment",
                column: "WithArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Comment");

            migrationBuilder.DropTable(
                name: "T_Article");
        }
    }
}
