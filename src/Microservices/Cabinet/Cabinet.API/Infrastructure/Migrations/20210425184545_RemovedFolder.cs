using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cabinet.API.Migrations
{
    public partial class RemovedFolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentsAccesses_Folders_FolderID",
                table: "DocumentsAccesses");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_DocumentsAccesses_FolderID",
                table: "DocumentsAccesses");

            migrationBuilder.RenameColumn(
                name: "FolderID",
                table: "DocumentsAccesses",
                newName: "OrganizationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrganizationID",
                table: "DocumentsAccesses",
                newName: "FolderID");

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsAccesses_FolderID",
                table: "DocumentsAccesses",
                column: "FolderID");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentsAccesses_Folders_FolderID",
                table: "DocumentsAccesses",
                column: "FolderID",
                principalTable: "Folders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
