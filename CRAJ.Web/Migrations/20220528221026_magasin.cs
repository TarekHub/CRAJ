using Microsoft.EntityFrameworkCore.Migrations;

namespace CRAJ.Web.Migrations
{
    public partial class magasin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Magasin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomMagasin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConseilJudiciaireId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magasin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Magasin_ConseilJudiciaire_ConseilJudiciaireId",
                        column: x => x.ConseilJudiciaireId,
                        principalTable: "ConseilJudiciaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Magasin_ConseilJudiciaireId",
                table: "Magasin",
                column: "ConseilJudiciaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Magasin");
        }
    }
}
