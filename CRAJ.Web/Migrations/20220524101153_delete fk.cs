using Microsoft.EntityFrameworkCore.Migrations;

namespace CRAJ.Web.Migrations
{
    public partial class deletefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_TypeDoc_IdTypeDoc",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_IdTypeDoc",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "IdTypeDoc",
                table: "Document");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Document",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Document");

            migrationBuilder.AddColumn<int>(
                name: "IdTypeDoc",
                table: "Document",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Document_IdTypeDoc",
                table: "Document",
                column: "IdTypeDoc");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_TypeDoc_IdTypeDoc",
                table: "Document",
                column: "IdTypeDoc",
                principalTable: "TypeDoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
