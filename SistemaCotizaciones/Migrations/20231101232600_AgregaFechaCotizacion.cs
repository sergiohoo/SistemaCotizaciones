using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCotizaciones.Migrations
{
    public partial class AgregaFechaCotizacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCotizacion",
                table: "Cotizaciones",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCotizacion",
                table: "Cotizaciones");
        }
    }
}
