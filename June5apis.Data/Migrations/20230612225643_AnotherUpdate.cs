using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace June5apis.Data.Migrations
{
    public partial class AnotherUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userLikedJokes_Jokes_JokeId",
                table: "userLikedJokes");

            migrationBuilder.DropForeignKey(
                name: "FK_userLikedJokes_Users_UserId",
                table: "userLikedJokes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userLikedJokes",
                table: "userLikedJokes");

            migrationBuilder.DropColumn(
                name: "Liked",
                table: "userLikedJokes");

            migrationBuilder.RenameTable(
                name: "userLikedJokes",
                newName: "UserLikedJokes");

            migrationBuilder.RenameIndex(
                name: "IX_userLikedJokes_JokeId",
                table: "UserLikedJokes",
                newName: "IX_UserLikedJokes_JokeId");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UserLikedJokes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikedJokes",
                table: "UserLikedJokes",
                columns: new[] { "UserId", "JokeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedJokes_Jokes_JokeId",
                table: "UserLikedJokes",
                column: "JokeId",
                principalTable: "Jokes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedJokes_Users_UserId",
                table: "UserLikedJokes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedJokes_Jokes_JokeId",
                table: "UserLikedJokes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedJokes_Users_UserId",
                table: "UserLikedJokes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikedJokes",
                table: "UserLikedJokes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserLikedJokes");

            migrationBuilder.RenameTable(
                name: "UserLikedJokes",
                newName: "userLikedJokes");

            migrationBuilder.RenameIndex(
                name: "IX_UserLikedJokes_JokeId",
                table: "userLikedJokes",
                newName: "IX_userLikedJokes_JokeId");

            migrationBuilder.AddColumn<bool>(
                name: "Liked",
                table: "userLikedJokes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userLikedJokes",
                table: "userLikedJokes",
                columns: new[] { "UserId", "JokeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_userLikedJokes_Jokes_JokeId",
                table: "userLikedJokes",
                column: "JokeId",
                principalTable: "Jokes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userLikedJokes_Users_UserId",
                table: "userLikedJokes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
