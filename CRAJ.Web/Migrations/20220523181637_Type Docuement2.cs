using Microsoft.EntityFrameworkCore.Migrations;

namespace CRAJ.Web.Migrations
{
    public partial class TypeDocuement2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_TypeDoc_TypeId",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_TypeId",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Document");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_TypeDoc_IdTypeDoc",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_IdTypeDoc",
                table: "Document");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Document",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Document_TypeId",
                table: "Document",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_TypeDoc_TypeId",
                table: "Document",
                column: "TypeId",
                principalTable: "TypeDoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
