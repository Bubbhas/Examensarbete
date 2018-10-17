using Microsoft.EntityFrameworkCore.Migrations;

namespace GameOfDojan.Data.Migrations
{
    public partial class Ett : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ShoePics_ShoePicId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ShoePicId",
                table: "Comments",
                newName: "IX_Comments_ShoePicId");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "ShoePics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ShoePics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ShoePics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageSource",
                table: "ShoePics",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Probability",
                table: "ShoePics",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoePics_ApplicationUserId1",
                table: "ShoePics",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ShoePics_ShoePicId",
                table: "Comments",
                column: "ShoePicId",
                principalTable: "ShoePics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoePics_AspNetUsers_ApplicationUserId1",
                table: "ShoePics",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ShoePics_ShoePicId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoePics_AspNetUsers_ApplicationUserId1",
                table: "ShoePics");

            migrationBuilder.DropIndex(
                name: "IX_ShoePics_ApplicationUserId1",
                table: "ShoePics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ShoePics");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ShoePics");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ShoePics");

            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "ShoePics");

            migrationBuilder.DropColumn(
                name: "Probability",
                table: "ShoePics");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ShoePicId",
                table: "Comment",
                newName: "IX_Comment_ShoePicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ShoePics_ShoePicId",
                table: "Comment",
                column: "ShoePicId",
                principalTable: "ShoePics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
