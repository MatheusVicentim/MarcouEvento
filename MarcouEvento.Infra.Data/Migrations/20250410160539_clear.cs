using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcouEvento.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class clear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Complement", "Latitude", "Longitude", "Neighborhood", "Number", "State", "Street", "Type", "ZipCode" },
                values: new object[] { 1, "São João das Duas Pontes", "Casa", "", "", "Centro", 574, "UF", "R. Carlos Gomes", 0, "15640047" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
