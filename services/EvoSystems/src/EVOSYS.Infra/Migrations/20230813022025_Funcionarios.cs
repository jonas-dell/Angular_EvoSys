using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvoSystems.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Funcionarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Funcionarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Departamentos_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Departamentos_DepartamentoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Funcionarios");
        }
    }
}
