using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCotizaciones.Migrations
{
    public partial class IniciaModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canales",
                columns: table => new
                {
                    CanalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroClienteIngram = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canales", x => x.CanalId);
                });

            migrationBuilder.CreateTable(
                name: "ClientesFinales",
                columns: table => new
                {
                    ClienteFinalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesFinales", x => x.ClienteFinalId);
                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    FabricanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.FabricanteId);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoImpulse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioUnitario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "TiposCompra",
                columns: table => new
                {
                    TipoCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCompra", x => x.TipoCompraId);
                });

            migrationBuilder.CreateTable(
                name: "TiposCotizacion",
                columns: table => new
                {
                    TipoCotizacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCotizacion", x => x.TipoCotizacionId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "ContactosCanales",
                columns: table => new
                {
                    ContactoCanalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CanalId = table.Column<int>(type: "int", nullable: false),
                    Rut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactosCanales", x => x.ContactoCanalId);
                    table.ForeignKey(
                        name: "FK_ContactosCanales_Canales_CanalId",
                        column: x => x.CanalId,
                        principalTable: "Canales",
                        principalColumn: "CanalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactosClientesFinales",
                columns: table => new
                {
                    ContactoClienteFinalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteFinalId = table.Column<int>(type: "int", nullable: false),
                    Rut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactosClientesFinales", x => x.ContactoClienteFinalId);
                    table.ForeignKey(
                        name: "FK_ContactosClientesFinales_ClientesFinales_ClienteFinalId",
                        column: x => x.ClienteFinalId,
                        principalTable: "ClientesFinales",
                        principalColumn: "ClienteFinalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactosFabricantes",
                columns: table => new
                {
                    ContactoFabricanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FabricanteId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactosFabricantes", x => x.ContactoFabricanteId);
                    table.ForeignKey(
                        name: "FK_ContactosFabricantes_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "FabricanteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FabricanteId = table.Column<int>(type: "int", nullable: false),
                    ContactoFabricanteId = table.Column<int>(type: "int", nullable: false),
                    NumeroQuote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreOportunidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vigencia = table.Column<bool>(type: "bit", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                    table.ForeignKey(
                        name: "FK_Quotes_ContactosFabricantes_ContactoFabricanteId",
                        column: x => x.ContactoFabricanteId,
                        principalTable: "ContactosFabricantes",
                        principalColumn: "ContactoFabricanteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quotes_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "FabricanteId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                columns: table => new
                {
                    CotizacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FabricanteId = table.Column<int>(type: "int", nullable: false),
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    TipoCotizacionId = table.Column<int>(type: "int", nullable: false),
                    TipoCompraId = table.Column<int>(type: "int", nullable: false),
                    CanalId = table.Column<int>(type: "int", nullable: false),
                    ContactoCanalId = table.Column<int>(type: "int", nullable: false),
                    ClienteFinalId = table.Column<int>(type: "int", nullable: false),
                    ContactoClienteFinalId = table.Column<int>(type: "int", nullable: false),
                    Duty = table.Column<double>(type: "float", nullable: false),
                    Impuesto = table.Column<double>(type: "float", nullable: false),
                    Margen = table.Column<double>(type: "float", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => x.CotizacionId);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Canales_CanalId",
                        column: x => x.CanalId,
                        principalTable: "Canales",
                        principalColumn: "CanalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_ClientesFinales_ClienteFinalId",
                        column: x => x.ClienteFinalId,
                        principalTable: "ClientesFinales",
                        principalColumn: "ClienteFinalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_ContactosCanales_ContactoCanalId",
                        column: x => x.ContactoCanalId,
                        principalTable: "ContactosCanales",
                        principalColumn: "ContactoCanalId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_ContactosClientesFinales_ContactoClienteFinalId",
                        column: x => x.ContactoClienteFinalId,
                        principalTable: "ContactosClientesFinales",
                        principalColumn: "ContactoClienteFinalId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "FabricanteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_TiposCompra_TipoCompraId",
                        column: x => x.TipoCompraId,
                        principalTable: "TiposCompra",
                        principalColumn: "TipoCompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_TiposCotizacion_TipoCotizacionId",
                        column: x => x.TipoCotizacionId,
                        principalTable: "TiposCotizacion",
                        principalColumn: "TipoCotizacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialesCotizacion",
                columns: table => new
                {
                    MaterialCotizacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CotizacionId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    DescuentoPorcentaje = table.Column<double>(type: "float", nullable: true),
                    DescuentoAbsoluto = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaTermino = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialesCotizacion", x => x.MaterialCotizacionId);
                    table.ForeignKey(
                        name: "FK_MaterialesCotizacion_Cotizaciones_CotizacionId",
                        column: x => x.CotizacionId,
                        principalTable: "Cotizaciones",
                        principalColumn: "CotizacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialesCotizacion_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactosCanales_CanalId",
                table: "ContactosCanales",
                column: "CanalId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactosClientesFinales_ClienteFinalId",
                table: "ContactosClientesFinales",
                column: "ClienteFinalId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactosFabricantes_FabricanteId",
                table: "ContactosFabricantes",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_CanalId",
                table: "Cotizaciones",
                column: "CanalId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_ClienteFinalId",
                table: "Cotizaciones",
                column: "ClienteFinalId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_ContactoCanalId",
                table: "Cotizaciones",
                column: "ContactoCanalId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_ContactoClienteFinalId",
                table: "Cotizaciones",
                column: "ContactoClienteFinalId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_FabricanteId",
                table: "Cotizaciones",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_QuoteId",
                table: "Cotizaciones",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_TipoCompraId",
                table: "Cotizaciones",
                column: "TipoCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_TipoCotizacionId",
                table: "Cotizaciones",
                column: "TipoCotizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_UsuarioId",
                table: "Cotizaciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesCotizacion_CotizacionId",
                table: "MaterialesCotizacion",
                column: "CotizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesCotizacion_MaterialId",
                table: "MaterialesCotizacion",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_ContactoFabricanteId",
                table: "Quotes",
                column: "ContactoFabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_FabricanteId",
                table: "Quotes",
                column: "FabricanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialesCotizacion");

            migrationBuilder.DropTable(
                name: "Cotizaciones");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "ContactosCanales");

            migrationBuilder.DropTable(
                name: "ContactosClientesFinales");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "TiposCompra");

            migrationBuilder.DropTable(
                name: "TiposCotizacion");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Canales");

            migrationBuilder.DropTable(
                name: "ClientesFinales");

            migrationBuilder.DropTable(
                name: "ContactosFabricantes");

            migrationBuilder.DropTable(
                name: "Fabricantes");
        }
    }
}
