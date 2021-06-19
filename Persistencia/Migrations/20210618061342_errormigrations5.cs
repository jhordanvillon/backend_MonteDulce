using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class errormigrations5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleBoleta");

            migrationBuilder.DropTable(
                name: "Boleta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boleta",
                columns: table => new
                {
                    BoletaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Igv = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boleta", x => x.BoletaId);
                });

            migrationBuilder.CreateTable(
                name: "DetalleBoleta",
                columns: table => new
                {
                    BoletaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleBoleta", x => new { x.BoletaId, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_DetalleBoleta_Boleta_BoletaId",
                        column: x => x.BoletaId,
                        principalTable: "Boleta",
                        principalColumn: "BoletaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleBoleta_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleBoleta_ProductoId",
                table: "DetalleBoleta",
                column: "ProductoId");
        }
    }
}
