using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class cambiarItemBoleta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioItem",
                table: "ItemBoleta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecioItem",
                table: "ItemBoleta",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
