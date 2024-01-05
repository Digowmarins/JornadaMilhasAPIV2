using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JORNADAMILHASAPI.Migrations.Destino
{
    /// <inheritdoc />
    public partial class DestinoAtualizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Destinos",
                newName: "PicUrl2");

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Destinos",
                type: "varchar(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Destinos");

            migrationBuilder.RenameColumn(
                name: "PicUrl2",
                table: "Destinos",
                newName: "Price");
        }
    }
}
