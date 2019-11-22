using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteUpload.Migrations
{
    public partial class img64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imagens_Carro_CarroId",
                table: "imagens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_imagens",
                table: "imagens");

            migrationBuilder.RenameTable(
                name: "imagens",
                newName: "Imagens");

            migrationBuilder.RenameIndex(
                name: "IX_imagens_CarroId",
                table: "Imagens",
                newName: "IX_Imagens_CarroId");

            migrationBuilder.AddColumn<string>(
                name: "ImgBase64",
                table: "Imagens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgBase64",
                table: "Carro",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imagens",
                table: "Imagens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Carro_CarroId",
                table: "Imagens",
                column: "CarroId",
                principalTable: "Carro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Carro_CarroId",
                table: "Imagens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imagens",
                table: "Imagens");

            migrationBuilder.DropColumn(
                name: "ImgBase64",
                table: "Imagens");

            migrationBuilder.DropColumn(
                name: "ImgBase64",
                table: "Carro");

            migrationBuilder.RenameTable(
                name: "Imagens",
                newName: "imagens");

            migrationBuilder.RenameIndex(
                name: "IX_Imagens_CarroId",
                table: "imagens",
                newName: "IX_imagens_CarroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_imagens",
                table: "imagens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_imagens_Carro_CarroId",
                table: "imagens",
                column: "CarroId",
                principalTable: "Carro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
