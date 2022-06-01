using Microsoft.EntityFrameworkCore.Migrations;

namespace CRAJ.Web.Migrations
{
    public partial class deletingChambre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Chambre_ChambreId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChambreId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ChambreId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChambreId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChambreId",
                table: "AspNetUsers",
                column: "ChambreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Chambre_ChambreId",
                table: "AspNetUsers",
                column: "ChambreId",
                principalTable: "Chambre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
