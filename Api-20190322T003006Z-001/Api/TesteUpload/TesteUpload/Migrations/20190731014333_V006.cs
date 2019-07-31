using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteUpload.Migrations
{
    public partial class V006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Local",
                table: "Evento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Evento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Local",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Evento");
        }
    }
}
