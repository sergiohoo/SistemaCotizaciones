using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCotizaciones.Migrations
{
    public partial class AgregaPocc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pocc",
                columns: table => new
                {
                    PoccId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CotizacionId = table.Column<int>(type: "int", nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Incoterm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDespacho = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pocc", x => x.PoccId);
                    table.ForeignKey(
                        name: "FK_Pocc_Cotizaciones_CotizacionId",
                        column: x => x.CotizacionId,
                        principalTable: "Cotizaciones",
                        principalColumn: "CotizacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pocc_CotizacionId",
                table: "Pocc",
                column: "CotizacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pocc");
        }
    }
}
