using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCotizaciones.Migrations
{
    public partial class VuelveAUsarRuts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RutContactoClienteFinal",
                table: "ContactosClientesFinales",
                newName: "Rut");

            migrationBuilder.RenameColumn(
                name: "RutClienteFinal",
                table: "ClientesFinales",
                newName: "Rut");

            migrationBuilder.RenameColumn(
                name: "RutCanal",
                table: "Canales",
                newName: "Rut");
            migrationBuilder.RenameColumn(
                name: "RutContactoCanal",
                table: "ContactosCanales",
                newName: "Rut");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "ContactosClientesFinales",
                newName: "RutContactoClienteFinal");

            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "ClientesFinales",
                newName: "RutClienteFinal");

            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "Canales",
                newName: "RutCanal");
            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "ContactosCanales",
                newName: "RutContactoCanal");
        }
    }
}
