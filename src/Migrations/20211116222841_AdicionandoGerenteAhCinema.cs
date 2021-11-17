using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmes.Rest.Api.Net5.Migrations
{
    public partial class AdicionandoGerenteAhCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerentes_Gerente_Id",
                table: "Cinemas");

            migrationBuilder.RenameColumn(
                name: "Gerente_Id",
                table: "Cinemas",
                newName: "GerenteId");

            migrationBuilder.RenameIndex(
                name: "IX_Cinemas_Gerente_Id",
                table: "Cinemas",
                newName: "IX_Cinemas_GerenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteId",
                table: "Cinemas",
                column: "GerenteId",
                principalTable: "Gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteId",
                table: "Cinemas");

            migrationBuilder.RenameColumn(
                name: "GerenteId",
                table: "Cinemas",
                newName: "Gerente_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Cinemas_GerenteId",
                table: "Cinemas",
                newName: "IX_Cinemas_Gerente_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerentes_Gerente_Id",
                table: "Cinemas",
                column: "Gerente_Id",
                principalTable: "Gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
