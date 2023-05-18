using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore入门.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_T_Dog_Name",
                table: "T_Dog",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_T_Dog_Name",
                table: "T_Dog");
        }
    }
}
