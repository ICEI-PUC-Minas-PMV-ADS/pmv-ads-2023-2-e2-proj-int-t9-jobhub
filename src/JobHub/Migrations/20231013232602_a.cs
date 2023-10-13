using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobHub.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "Vagas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormaDeTrabalho",
                table: "Vagas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Local",
                table: "Vagas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nivel",
                table: "Vagas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salario",
                table: "Vagas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Vagas",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "FormaDeTrabalho",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "Local",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "Salario",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Vagas");
        }
    }
}
