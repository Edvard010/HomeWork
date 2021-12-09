using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWork.Migrations
{
    public partial class zmiana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNote");

            migrationBuilder.DropColumn(
                name: "No",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "CustomUserId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CustomUserId",
                table: "Notes",
                column: "CustomUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_CustomUserId",
                table: "Notes",
                column: "CustomUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_CustomUserId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CustomUserId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CustomUserId",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserNote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNote", x => new { x.Id, x.NoteId });
                    table.ForeignKey(
                        name: "FK_UserNote_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNote_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNote_NoteId",
                table: "UserNote",
                column: "NoteId");
        }
    }
}
