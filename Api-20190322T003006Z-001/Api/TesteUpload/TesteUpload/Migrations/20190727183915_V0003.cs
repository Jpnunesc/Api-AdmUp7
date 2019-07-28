using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteUpload.Migrations
{
    public partial class V0003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Combustivel",
                table: "Carro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Velocidade",
                table: "Carro",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Combustivel",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "Velocidade",
                table: "Carro");
        }
    }
}
