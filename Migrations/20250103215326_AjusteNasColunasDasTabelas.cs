using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNasColunasDasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Livros",
                newName: "titulo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Livros",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SobreNome",
                table: "Autores",
                newName: "sobrenome");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Autores",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Autores",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "titulo",
                table: "Livros",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Livros",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "sobrenome",
                table: "Autores",
                newName: "SobreNome");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Autores",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Autores",
                newName: "Id");
        }
    }
}
