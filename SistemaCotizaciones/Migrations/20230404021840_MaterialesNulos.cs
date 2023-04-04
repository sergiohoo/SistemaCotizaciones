using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCotizaciones.Migrations
{
    public partial class MaterialesNulos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialesCotizacion_Cotizaciones_CotizacionId",
                table: "MaterialesCotizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialesCotizacion_Materiales_MaterialId",
                table: "MaterialesCotizacion");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "MaterialesCotizacion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaTermino",
                table: "MaterialesCotizacion",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaInicio",
                table: "MaterialesCotizacion",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "DescuentoAbsoluto",
                table: "MaterialesCotizacion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CotizacionId",
                table: "MaterialesCotizacion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "MaterialesCotizacion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PrecioUnitario",
                table: "MaterialesCotizacion",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sku",
                table: "Materiales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrecioUnitario",
                table: "Materiales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroSerie",
                table: "Materiales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Materiales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialesCotizacion_Cotizaciones_CotizacionId",
                table: "MaterialesCotizacion",
                column: "CotizacionId",
                principalTable: "Cotizaciones",
                principalColumn: "CotizacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialesCotizacion_Materiales_MaterialId",
                table: "MaterialesCotizacion",
                column: "MaterialId",
                principalTable: "Materiales",
                principalColumn: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialesCotizacion_Cotizaciones_CotizacionId",
                table: "MaterialesCotizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialesCotizacion_Materiales_MaterialId",
                table: "MaterialesCotizacion");

            migrationBuilder.DropColumn(
                name: "PrecioUnitario",
                table: "MaterialesCotizacion");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "MaterialesCotizacion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaTermino",
                table: "MaterialesCotizacion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaInicio",
                table: "MaterialesCotizacion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DescuentoAbsoluto",
                table: "MaterialesCotizacion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CotizacionId",
                table: "MaterialesCotizacion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "MaterialesCotizacion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sku",
                table: "Materiales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PrecioUnitario",
                table: "Materiales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroSerie",
                table: "Materiales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Materiales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialesCotizacion_Cotizaciones_CotizacionId",
                table: "MaterialesCotizacion",
                column: "CotizacionId",
                principalTable: "Cotizaciones",
                principalColumn: "CotizacionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialesCotizacion_Materiales_MaterialId",
                table: "MaterialesCotizacion",
                column: "MaterialId",
                principalTable: "Materiales",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
