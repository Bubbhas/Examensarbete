using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameOfDojan.Data.Migrations
{
    public partial class AddedLikesAndStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "ShoePics");

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    DateOfLike = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    ShoePicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.ApplicationUserId, x.ShoePicId });
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_ShoePics_ShoePicId",
                        column: x => x.ShoePicId,
                        principalTable: "ShoePics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ShoePicId",
                table: "Likes",
                column: "ShoePicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "ShoePics",
                nullable: false,
                defaultValue: 0);
        }
    }
}
