using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteUpload.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caminho",
                table: "Imagens");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "CaminhoImagem",
                table: "Carro");

            migrationBuilder.RenameColumn(
                name: "Imagem",
                table: "Rifa",
                newName: "ImgBase64");

            migrationBuilder.RenameColumn(
                name: "Imagem",
                table: "Parceiros",
                newName: "ImgBase64");

            migrationBuilder.RenameColumn(
                name: "Imagem",
                table: "Instituicao",
                newName: "ImgBase64");

            migrationBuilder.AddColumn<string>(
                name: "ImgBase64",
                table: "Evento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgBase64",
                table: "Evento");

            migrationBuilder.RenameColumn(
                name: "ImgBase64",
                table: "Rifa",
                newName: "Imagem");

            migrationBuilder.RenameColumn(
                name: "ImgBase64",
                table: "Parceiros",
                newName: "Imagem");

            migrationBuilder.RenameColumn(
                name: "ImgBase64",
                table: "Instituicao",
                newName: "Imagem");

            migrationBuilder.AddColumn<string>(
                name: "Caminho",
                table: "Imagens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Evento",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CaminhoImagem",
                table: "Carro",
                nullable: true);
        }
    }
}
