using Microsoft.EntityFrameworkCore.Migrations;

namespace Cabinet.API.Migrations
{
    public partial class AddedDocumentName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Document",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Document");
        }
    }
}
