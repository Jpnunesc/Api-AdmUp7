using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteUpload.Migrations
{
    public partial class v004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArCondicionado",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "Bancos",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "Freios",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "PaisOrigem",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "Rodas",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "StatusCarro",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "Tracao",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "Vidros",
                table: "Carro");

            migrationBuilder.CreateTable(
                name: "Adicional",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    IdCarro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adicional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adicional_Carro_IdCarro",
                        column: x => x.IdCarro,
                        principalTable: "Carro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adicional_IdCarro",
                table: "Adicional",
                column: "IdCarro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adicional");

            migrationBuilder.AddColumn<string>(
                name: "ArCondicionado",
                table: "Carro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bancos",
                table: "Carro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Freios",
                table: "Carro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaisOrigem",
                table: "Carro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rodas",
                table: "Carro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusCarro",
                table: "Carro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tracao",
                table: "Carro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vidros",
                table: "Carro",
                nullable: true);
        }
    }
}
