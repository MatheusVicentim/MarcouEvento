using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcouEvento.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoUrlMapsAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlMaps",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlMaps",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlMaps",
                table: "Addresses");
        }
    }
}
