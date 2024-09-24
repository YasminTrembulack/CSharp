using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Musify.Migrations
{
    /// <inheritdoc />
    public partial class RemovingExtraUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Users_UserId1",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_UserId1",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Musics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Musics",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musics_UserId1",
                table: "Musics",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Users_UserId1",
                table: "Musics",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
