using Microsoft.EntityFrameworkCore.Migrations;

namespace CRAJ.Web.Migrations
{
    public partial class isinprogress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isInProgress",
                table: "Document",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isInProgress",
                table: "Document");
        }
    }
}
