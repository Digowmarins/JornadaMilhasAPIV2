using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JORNADAMILHASAPI.Migrations.Destino
{
    /// <inheritdoc />
    public partial class DestinoAtualizado1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Destinos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Destinos");
        }
    }
}
