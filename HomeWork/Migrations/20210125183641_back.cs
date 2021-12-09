using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWork.Migrations
{
    public partial class back : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoteEntityForeignKey",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteEntityForeignKey",
                table: "Notes");
        }
    }
}
