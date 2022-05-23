using Microsoft.EntityFrameworkCore.Migrations;

namespace CRAJ.Web.Migrations
{
    public partial class TypeDOcuement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Document",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeDoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDoc", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_TypeDoc_TypeId",
                table: "Document");

            migrationBuilder.DropTable(
                name: "TypeDoc");

            migrationBuilder.DropIndex(
                name: "IX_Document_TypeId",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "IdTypeDoc",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Document");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Document",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
