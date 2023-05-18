using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore入门.Migrations
{
    /// <inheritdoc />
    public partial class AddCat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Cat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Cat", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Cat_Name",
                table: "T_Cat",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Cat");
        }
    }
}
