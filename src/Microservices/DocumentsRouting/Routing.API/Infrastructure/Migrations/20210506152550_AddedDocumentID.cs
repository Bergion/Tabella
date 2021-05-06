using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Routing.API.Migrations
{
    public partial class AddedDocumentID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DocumentID",
                table: "Routes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentID",
                table: "Routes");
        }
    }
}
