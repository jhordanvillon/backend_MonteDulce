using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class errormigrations6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boleta",
                columns: table => new
                {
                    BoletaId = table.Column<Guid>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boleta", x => x.BoletaId);
                });

            migrationBuilder.CreateTable(
                name: "ItemBoleta",
                columns: table => new
                {
                    ItemBoletaId = table.Column<Guid>(nullable: false),
                    BoletaId = table.Column<Guid>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    ProductoId = table.Column<Guid>(nullable: false),
                    PrecioItem = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBoleta", x => x.ItemBoletaId);
                    table.ForeignKey(
                        name: "FK_ItemBoleta_Boleta_BoletaId",
                        column: x => x.BoletaId,
                        principalTable: "Boleta",
                        principalColumn: "BoletaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemBoleta_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    PedidoId = table.Column<Guid>(nullable: false),
                    BoletaId = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    UsuarioId1 = table.Column<string>(nullable: true),
                    CodigoPago = table.Column<string>(nullable: true),
                    TipoPedido = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedido_Boleta_BoletaId",
                        column: x => x.BoletaId,
                        principalTable: "Boleta",
                        principalColumn: "BoletaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_AspNetUsers_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemBoleta_BoletaId",
                table: "ItemBoleta",
                column: "BoletaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBoleta_ProductoId",
                table: "ItemBoleta",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_BoletaId",
                table: "Pedido",
                column: "BoletaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_UsuarioId1",
                table: "Pedido",
                column: "UsuarioId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemBoleta");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Boleta");
        }
    }
}
