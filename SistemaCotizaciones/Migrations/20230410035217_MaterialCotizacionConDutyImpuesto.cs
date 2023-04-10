using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCotizaciones.Migrations
{
    public partial class MaterialCotizacionConDutyImpuesto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duty",
                table: "Cotizaciones");

            migrationBuilder.DropColumn(
                name: "Impuesto",
                table: "Cotizaciones");

            migrationBuilder.RenameColumn(
                name: "Sku",
                table: "Materiales",
                newName: "TipoMaterial");

            migrationBuilder.AddColumn<double>(
                name: "ImpuestoDuty",
                table: "MaterialesCotizacion",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PrecioCliente",
                table: "MaterialesCotizacion",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImpuestoDuty",
                table: "MaterialesCotizacion");

            migrationBuilder.DropColumn(
                name: "PrecioCliente",
                table: "MaterialesCotizacion");

            migrationBuilder.RenameColumn(
                name: "TipoMaterial",
                table: "Materiales",
                newName: "Sku");

            migrationBuilder.AddColumn<double>(
                name: "Duty",
                table: "Cotizaciones",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Impuesto",
                table: "Cotizaciones",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
