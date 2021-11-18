using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmes.Rest.Api.Net5.Migrations
{
    public partial class AdicionandoGerenteseCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gerente_Id",
                table: "Cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_Gerente_Id",
                table: "Cinemas",
                column: "Gerente_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerentes_Gerente_Id",
                table: "Cinemas",
                column: "Gerente_Id",
                principalTable: "Gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerentes_Gerente_Id",
                table: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_Gerente_Id",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "Gerente_Id",
                table: "Cinemas");
        }
    }
}
