using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRAJ.Web.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentArchiveRegional");

            migrationBuilder.AddColumn<bool>(
                name: "isInArchived",
                table: "Document",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isInConseilJ",
                table: "Document",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isInTribunal",
                table: "Document",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isInArchived",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "isInConseilJ",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "isInTribunal",
                table: "Document");

            migrationBuilder.CreateTable(
                name: "DocumentArchiveRegional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ChambreId = table.Column<int>(type: "int", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentImage = table.Column<string>(type: "varchar(max)", nullable: true),
                    IdPersonne = table.Column<int>(type: "int", nullable: false),
                    TribunalId = table.Column<int>(type: "int", nullable: true),
                    TypeArchive = table.Column<int>(type: "int", nullable: false),
                    TypeDocuementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentArchiveRegional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentArchiveRegional_Chambre_ChambreId",
                        column: x => x.ChambreId,
                        principalTable: "Chambre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentArchiveRegional_Tribunal_TribunalId",
                        column: x => x.TribunalId,
                        principalTable: "Tribunal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentArchiveRegional_TypeDoc_TypeDocuementId",
                        column: x => x.TypeDocuementId,
                        principalTable: "TypeDoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentArchiveRegional_ChambreId",
                table: "DocumentArchiveRegional",
                column: "ChambreId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentArchiveRegional_TribunalId",
                table: "DocumentArchiveRegional",
                column: "TribunalId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentArchiveRegional_TypeDocuementId",
                table: "DocumentArchiveRegional",
                column: "TypeDocuementId");
        }
    }
}
