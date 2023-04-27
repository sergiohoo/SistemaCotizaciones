using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCotizaciones.Migrations
{
    public partial class CambiaCodigoImpulsePorMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodigoImpulse",
                table: "Materiales",
                newName: "MaterialSap");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaterialSap",
                table: "Materiales",
                newName: "CodigoImpulse");
        }
    }
}
