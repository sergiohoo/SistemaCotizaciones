﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaCotizaciones.Model;

#nullable disable

namespace SistemaCotizaciones.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230629101739_VuelveAUsarRuts")]
    partial class VuelveAUsarRuts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SistemaCotizaciones.Model.Canal", b =>
                {
                    b.Property<int>("CanalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CanalId"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroClienteIngram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CanalId");

                    b.ToTable("Canales");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.ClienteFinal", b =>
                {
                    b.Property<int>("ClienteFinalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteFinalId"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteFinalId");

                    b.ToTable("ClientesFinales");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.ContactoCanal", b =>
                {
                    b.Property<int>("ContactoCanalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactoCanalId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CanalId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactoCanalId");

                    b.HasIndex("CanalId");

                    b.ToTable("ContactosCanales");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.ContactoClienteFinal", b =>
                {
                    b.Property<int>("ContactoClienteFinalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactoClienteFinalId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClienteFinalId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactoClienteFinalId");

                    b.HasIndex("ClienteFinalId");

                    b.ToTable("ContactosClientesFinales");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.ContactoFabricante", b =>
                {
                    b.Property<int>("ContactoFabricanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactoFabricanteId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FabricanteId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactoFabricanteId");

                    b.HasIndex("FabricanteId");

                    b.ToTable("ContactosFabricantes");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.Cotizacion", b =>
                {
                    b.Property<int>("CotizacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CotizacionId"), 1L, 1);

                    b.Property<int>("CanalId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteFinalId")
                        .HasColumnType("int");

                    b.Property<int>("ContactoCanalId")
                        .HasColumnType("int");

                    b.Property<int>("ContactoClienteFinalId")
                        .HasColumnType("int");

                    b.Property<int>("FabricanteId")
                        .HasColumnType("int");

                    b.Property<decimal>("Margen")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuoteId")
                        .HasColumnType("int");

                    b.Property<int>("TipoCompraId")
                        .HasColumnType("int");

                    b.Property<int>("TipoCotizacionId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalIVA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalNeto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("CotizacionId");

                    b.HasIndex("CanalId");

                    b.HasIndex("ClienteFinalId");

                    b.HasIndex("ContactoCanalId");

                    b.HasIndex("ContactoClienteFinalId");

                    b.HasIndex("FabricanteId");

                    b.HasIndex("QuoteId");

                    b.HasIndex("TipoCompraId");

                    b.HasIndex("TipoCotizacionId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cotizaciones");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.Fabricante", b =>
                {
                    b.Property<int>("FabricanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FabricanteId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FabricanteId");

                    b.ToTable("Fabricantes");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialSap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PrecioUnitario")
                        .HasColumnType("int");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaterialId");

                    b.ToTable("Materiales");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.MaterialCotizacion", b =>
                {
                    b.Property<int>("MaterialCotizacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialCotizacionId"), 1L, 1);

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("CodigoImpulse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CostoFinalTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CostoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CotizacionId")
                        .HasColumnType("int");

                    b.Property<decimal?>("DescuentoAbsoluto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DescuentoPorcentaje")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaTermino")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("ImpuestoDuty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Intercompany")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Margen")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("MaterialId")
                        .HasColumnType("int");

                    b.Property<decimal?>("MontoInternacion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NumeroSerie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PrecioCliente")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PrecioFob")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PrecioUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoMaterial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalNeto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("UnoPorcientoFinanciero")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaterialCotizacionId");

                    b.HasIndex("CotizacionId");

                    b.HasIndex("MaterialId");

                    b.ToTable("MaterialesCotizacion");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.Pocc", b =>
                {
                    b.Property<int>("PoccId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PoccId"), 1L, 1);

                    b.Property<int>("CotizacionId")
                        .HasColumnType("int");

                    b.Property<string>("Incoterm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDespacho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PoccId");

                    b.HasIndex("CotizacionId");

                    b.ToTable("Pocc");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuoteId"), 1L, 1);

                    b.Property<int>("ContactoFabricanteId")
                        .HasColumnType("int");

                    b.Property<int>("FabricanteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreOportunidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroQuote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Vigencia")
                        .HasColumnType("bit");

                    b.HasKey("QuoteId");

                    b.HasIndex("ContactoFabricanteId");

                    b.HasIndex("FabricanteId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.TipoCompra", b =>
                {
                    b.Property<int>("TipoCompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoCompraId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoCompraId");

                    b.ToTable("TiposCompra");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.TipoCotizacion", b =>
                {
                    b.Property<int>("TipoCotizacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoCotizacionId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoCotizacionId");

                    b.ToTable("TiposCotizacion");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.ContactoCanal", b =>
                {
                    b.HasOne("SistemaCotizaciones.Model.Canal", "Canal")
                        .WithMany("Contactos")
                        .HasForeignKey("CanalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Canal");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.ContactoClienteFinal", b =>
                {
                    b.HasOne("SistemaCotizaciones.Model.ClienteFinal", "ClienteFinal")
                        .WithMany("Contactos")
                        .HasForeignKey("ClienteFinalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClienteFinal");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.ContactoFabricante", b =>
                {
                    b.HasOne("SistemaCotizaciones.Model.Fabricante", "Fabricante")
                        .WithMany("Contactos")
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fabricante");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.Cotizacion", b =>
                {
                    b.HasOne("SistemaCotizaciones.Model.Canal", "Canal")
                        .WithMany()
                        .HasForeignKey("CanalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCotizaciones.Model.ClienteFinal", "ClienteFinal")
                        .WithMany()
                        .HasForeignKey("ClienteFinalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCotizaciones.Model.ContactoCanal", "ContactoCanal")
                        .WithMany()
                        .HasForeignKey("ContactoCanalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCotizaciones.Model.ContactoClienteFinal", "ContactoClienteFinal")
                        .WithMany()
                        .HasForeignKey("ContactoClienteFinalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCotizaciones.Model.Fabricante", "Fabricante")
                        .WithMany()
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCotizaciones.Model.Quote", "Quote")
                        .WithMany("Cotizaciones")
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCotizaciones.Model.TipoCompra", "TipoCompra")
                        .WithMany()
                        .HasForeignKey("TipoCompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCotizaciones.Model.TipoCotizacion", "TipoCotizacion")
                        .WithMany()
                        .HasForeignKey("TipoCotizacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCotizaciones.Model.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Canal");

                    b.Navigation("ClienteFinal");

                    b.Navigation("ContactoCanal");

                    b.Navigation("ContactoClienteFinal");

                    b.Navigation("Fabricante");

                    b.Navigation("Quote");

                    b.Navigation("TipoCompra");

                    b.Navigation("TipoCotizacion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.MaterialCotizacion", b =>
                {
                    b.HasOne("SistemaCotizaciones.Model.Cotizacion", "Cotizacion")
                        .WithMany("MaterialesCotizacion")
                        .HasForeignKey("CotizacionId");

                    b.HasOne("SistemaCotizaciones.Model.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.Navigation("Cotizacion");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.Pocc", b =>
                {
                    b.HasOne("SistemaCotizaciones.Model.Cotizacion", "Cotizacion")
                        .WithMany()
                        .HasForeignKey("CotizacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cotizacion");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.Quote", b =>
                {
                    b.HasOne("SistemaCotizaciones.Model.ContactoFabricante", "ContactoFabricante")
                        .WithMany("Quotes")
                        .HasForeignKey("ContactoFabricanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCotizaciones.Model.Fabricante", "Fabricante")
                        .WithMany("Quotes")
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactoFabricante");

                    b.Navigation("Fabricante");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.Canal", b =>
                {
                    b.Navigation("Contactos");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.ClienteFinal", b =>
                {
                    b.Navigation("Contactos");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.ContactoFabricante", b =>
                {
                    b.Navigation("Quotes");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.Cotizacion", b =>
                {
                    b.Navigation("MaterialesCotizacion");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.Fabricante", b =>
                {
                    b.Navigation("Contactos");

                    b.Navigation("Quotes");
                });

            modelBuilder.Entity("SistemaCotizaciones.Model.Quote", b =>
                {
                    b.Navigation("Cotizaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
