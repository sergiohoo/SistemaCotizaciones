using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCotizaciones.Migrations
{
    public partial class AgregaCamposPocc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Materiales",
                newName: "Sku");

            migrationBuilder.AddColumn<string>(
                name: "CodigoImpulse",
                table: "MaterialesCotizacion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostoFinalTotal",
                table: "MaterialesCotizacion",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostoTotal",
                table: "MaterialesCotizacion",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Intercompany",
                table: "MaterialesCotizacion",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Margen",
                table: "MaterialesCotizacion",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoInternacion",
                table: "MaterialesCotizacion",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioFob",
                table: "MaterialesCotizacion",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnoPorcientoFinanciero",
                table: "MaterialesCotizacion",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoImpulse",
                table: "MaterialesCotizacion");

            migrationBuilder.DropColumn(
                name: "CostoFinalTotal",
                table: "MaterialesCotizacion");

            migrationBuilder.DropColumn(
                name: "CostoTotal",
                table: "MaterialesCotizacion");

            migrationBuilder.DropColumn(
                name: "Intercompany",
                table: "MaterialesCotizacion");

            migrationBuilder.DropColumn(
                name: "Margen",
                table: "MaterialesCotizacion");

            migrationBuilder.DropColumn(
                name: "MontoInternacion",
                table: "MaterialesCotizacion");

            migrationBuilder.DropColumn(
                name: "PrecioFob",
                table: "MaterialesCotizacion");

            migrationBuilder.DropColumn(
                name: "UnoPorcientoFinanciero",
                table: "MaterialesCotizacion");

            migrationBuilder.RenameColumn(
                name: "Sku",
                table: "Materiales",
                newName: "Nombre");
        }
    }
}
