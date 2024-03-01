using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class IdCardRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIdCard_Users_UserId",
                table: "UserIdCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIdCard",
                table: "UserIdCard");

            migrationBuilder.RenameTable(
                name: "UserIdCard",
                newName: "IdCards");

            migrationBuilder.RenameIndex(
                name: "IX_UserIdCard_UserId",
                table: "IdCards",
                newName: "IX_IdCards_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdCards",
                table: "IdCards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdCards_Users_UserId",
                table: "IdCards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdCards_Users_UserId",
                table: "IdCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdCards",
                table: "IdCards");

            migrationBuilder.RenameTable(
                name: "IdCards",
                newName: "UserIdCard");

            migrationBuilder.RenameIndex(
                name: "IX_IdCards_UserId",
                table: "UserIdCard",
                newName: "IX_UserIdCard_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIdCard",
                table: "UserIdCard",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIdCard_Users_UserId",
                table: "UserIdCard",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
