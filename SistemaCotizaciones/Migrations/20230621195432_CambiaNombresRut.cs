using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCotizaciones.Migrations
{
    public partial class CambiaNombresRut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "ContactosClientesFinales",
                newName: "RutContactoClienteFinal");

            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "ContactosCanales",
                newName: "Rut");

            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "ClientesFinales",
                newName: "RutClienteFinal");

            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "Canales",
                newName: "RutCanal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RutContactoClienteFinal",
                table: "ContactosClientesFinales",
                newName: "Rut");

            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "ContactosCanales",
                newName: "Rut");

            migrationBuilder.RenameColumn(
                name: "RutClienteFinal",
                table: "ClientesFinales",
                newName: "Rut");

            migrationBuilder.RenameColumn(
                name: "RutCanal",
                table: "Canales",
                newName: "Rut");
        }
    }
}
