using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JORNADAMILHASAPI.Migrations.Destino
{
    /// <inheritdoc />
    public partial class Destino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicUrl",
                table: "Destinos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicUrl",
                table: "Destinos");
        }
    }
}
