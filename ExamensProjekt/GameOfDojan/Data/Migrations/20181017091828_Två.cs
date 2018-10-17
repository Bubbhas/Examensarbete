using Microsoft.EntityFrameworkCore.Migrations;

namespace GameOfDojan.Data.Migrations
{
    public partial class Två : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoePics_AspNetUsers_ApplicationUserId1",
                table: "ShoePics");

            migrationBuilder.DropIndex(
                name: "IX_ShoePics_ApplicationUserId1",
                table: "ShoePics");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ShoePics");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ShoePics",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_ShoePics_ApplicationUserId",
                table: "ShoePics",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoePics_AspNetUsers_ApplicationUserId",
                table: "ShoePics",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoePics_AspNetUsers_ApplicationUserId",
                table: "ShoePics");

            migrationBuilder.DropIndex(
                name: "IX_ShoePics_ApplicationUserId",
                table: "ShoePics");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ShoePics",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ShoePics",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoePics_ApplicationUserId1",
                table: "ShoePics",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoePics_AspNetUsers_ApplicationUserId1",
                table: "ShoePics",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
