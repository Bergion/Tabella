using Microsoft.EntityFrameworkCore.Migrations;

namespace Cabinet.API.Migrations
{
    public partial class UniqueDocTypeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniqueName",
                table: "DocumentType",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueName",
                table: "DocumentType");
        }
    }
}
