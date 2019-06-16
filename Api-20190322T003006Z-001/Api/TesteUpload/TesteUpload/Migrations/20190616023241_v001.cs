using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteUpload.Migrations
{
    public partial class v001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Rifa",
                newName: "Quantidade");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadaRestante",
                table: "Rifa",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadaRestante",
                table: "Rifa");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Rifa",
                newName: "Numero");
        }
    }
}
