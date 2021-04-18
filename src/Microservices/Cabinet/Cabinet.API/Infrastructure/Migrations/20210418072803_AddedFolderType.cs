using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cabinet.API.Migrations
{
    public partial class AddedFolderType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentFolderID",
                table: "Document",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Folder",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    OrganizationID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folder", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_ParentFolderID",
                table: "Document",
                column: "ParentFolderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Folder_ParentFolderID",
                table: "Document",
                column: "ParentFolderID",
                principalTable: "Folder",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Folder_ParentFolderID",
                table: "Document");

            migrationBuilder.DropTable(
                name: "Folder");

            migrationBuilder.DropIndex(
                name: "IX_Document_ParentFolderID",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "ParentFolderID",
                table: "Document");
        }
    }
}
