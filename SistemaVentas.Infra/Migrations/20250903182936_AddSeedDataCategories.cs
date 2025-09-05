using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaVentas.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "IdCategoria", "FechaCreacion", "Nombre" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 9, 3, 18, 29, 36, 351, DateTimeKind.Utc).AddTicks(9701), "Ropa" },
                    { 3, new DateTime(2025, 9, 3, 18, 29, 36, 351, DateTimeKind.Utc).AddTicks(9707), "Libros" },
                    { 4, new DateTime(2025, 9, 3, 18, 29, 36, 351, DateTimeKind.Utc).AddTicks(9707), "Cosméticos" },
                    { 5, new DateTime(2025, 9, 3, 18, 29, 36, 351, DateTimeKind.Utc).AddTicks(9708), "Hogar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "IdCategoria",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "IdCategoria",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "IdCategoria",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "IdCategoria",
                keyValue: 5);
        }
    }
}
