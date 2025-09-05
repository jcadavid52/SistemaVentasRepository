using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddTableInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroFactura = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Iva = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_Factura_Pedidos_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "IdCategoria",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 9, 3, 21, 53, 36, 232, DateTimeKind.Utc).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "IdCategoria",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2025, 9, 3, 21, 53, 36, 232, DateTimeKind.Utc).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "IdCategoria",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2025, 9, 3, 21, 53, 36, 232, DateTimeKind.Utc).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "IdCategoria",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2025, 9, 3, 21, 53, 36, 232, DateTimeKind.Utc).AddTicks(5098));

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "IdCategoria", "FechaCreacion", "Nombre" },
                values: new object[] { 1, new DateTime(2025, 9, 3, 21, 53, 36, 232, DateTimeKind.Utc).AddTicks(5090), "Tecnología" });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdPedido",
                table: "Factura",
                column: "IdPedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "IdCategoria",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "IdCategoria",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 9, 3, 18, 29, 36, 351, DateTimeKind.Utc).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "IdCategoria",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2025, 9, 3, 18, 29, 36, 351, DateTimeKind.Utc).AddTicks(9707));

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "IdCategoria",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2025, 9, 3, 18, 29, 36, 351, DateTimeKind.Utc).AddTicks(9707));

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "IdCategoria",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2025, 9, 3, 18, 29, 36, 351, DateTimeKind.Utc).AddTicks(9708));
        }
    }
}
