using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteUpload.Migrations
{
    public partial class v005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Portas",
                table: "Carro",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Portas",
                table: "Carro");
        }
    }
}
