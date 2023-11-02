using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCotizaciones.Migrations
{
    public partial class AgregaTotalCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalCompra",
                table: "MaterialesCotizacion",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCompra",
                table: "Cotizaciones",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCompra",
                table: "MaterialesCotizacion");

            migrationBuilder.DropColumn(
                name: "TotalCompra",
                table: "Cotizaciones");
        }
    }
}
