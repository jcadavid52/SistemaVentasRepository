using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RenamePropertiesCreateAtAndCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categoria_CategoryId",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Productos",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Productos",
                newName: "IdCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_CategoryId",
                table: "Productos",
                newName: "IX_Productos_IdCategoria");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Categoria",
                newName: "FechaCreacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categoria_IdCategoria",
                table: "Productos",
                column: "IdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categoria_IdCategoria",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "Productos",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Productos",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                newName: "IX_Productos_CategoryId");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Categoria",
                newName: "CreatedAt");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categoria_CategoryId",
                table: "Productos",
                column: "CategoryId",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
