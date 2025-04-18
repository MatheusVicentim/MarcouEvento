﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcouEvento.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Addresses");
        }
    }
}
