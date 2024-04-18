﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entidades.Archivos", b =>
                {
                    b.Property<int>("IDArchivo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDArchivo"));

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<int>("IDPrestamo")
                        .HasColumnType("integer");

                    b.Property<int>("IDTipoarch")
                        .HasColumnType("integer");

                    b.HasKey("IDArchivo");

                    b.HasIndex("IDPrestamo");

                    b.HasIndex("IDTipoarch");

                    b.ToTable("Archivos", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Archivos_Prestamos", b =>
                {
                    b.Property<int>("IDArchpres")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDArchpres"));

                    b.Property<int>("IDArchivo")
                        .HasColumnType("integer");

                    b.Property<int>("IDPrestamo")
                        .HasColumnType("integer");

                    b.HasKey("IDArchpres");

                    b.HasIndex("IDArchivo");

                    b.HasIndex("IDPrestamo");

                    b.ToTable("Archivos_Prestamos", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Cuentas", b =>
                {
                    b.Property<int>("IDCuenta")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(35)
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDCuenta"));

                    b.Property<int>("CI")
                        .HasColumnType("integer");

                    b.Property<int>("Saldo")
                        .HasMaxLength(35)
                        .HasColumnType("integer");

                    b.HasKey("IDCuenta");

                    b.HasIndex("CI");

                    b.ToTable("Cuentas", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Cuotas", b =>
                {
                    b.Property<int>("IDCuota")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(35)
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDCuota"));

                    b.Property<int>("IDPrestamo")
                        .HasColumnType("integer");

                    b.HasKey("IDCuota");

                    b.HasIndex("IDPrestamo");

                    b.ToTable("Cuotas", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Movimientos", b =>
                {
                    b.Property<int>("IDMovimiento")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(35)
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDMovimiento"));

                    b.Property<DateTime>("Fecha")
                        .HasMaxLength(35)
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IDCuentaAcreditada")
                        .HasColumnType("integer");

                    b.Property<int>("IDCuentaDebitada")
                        .HasColumnType("integer");

                    b.Property<int>("IDTipo")
                        .HasColumnType("integer");

                    b.Property<double>("Monto")
                        .HasMaxLength(35)
                        .HasColumnType("double precision");

                    b.HasKey("IDMovimiento");

                    b.HasIndex("IDCuentaAcreditada");

                    b.HasIndex("IDCuentaDebitada");

                    b.HasIndex("IDTipo");

                    b.ToTable("Movimientos", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Prestamos", b =>
                {
                    b.Property<int>("IDPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(35)
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDPrestamo"));

                    b.Property<int>("CantCuotas")
                        .HasMaxLength(35)
                        .HasColumnType("integer");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.Property<DateTime>("FechaDeOperacion")
                        .HasMaxLength(35)
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IDCuenta")
                        .HasColumnType("integer");

                    b.Property<int>("IDTasa")
                        .HasColumnType("integer");

                    b.Property<double>("Monto")
                        .HasMaxLength(35)
                        .HasColumnType("double precision");

                    b.HasKey("IDPrestamo");

                    b.HasIndex("IDCuenta");

                    b.HasIndex("IDTasa");

                    b.ToTable("Prestamos", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Sesion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CedulaUsuario")
                        .HasColumnType("integer");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(227)
                        .HasColumnType("character varying(227)");

                    b.HasKey("Id");

                    b.HasIndex("CedulaUsuario");

                    b.ToTable("Sesiones", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Tasas", b =>
                {
                    b.Property<int>("IDTasa")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5)
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDTasa"));

                    b.Property<int>("Porcentaje")
                        .HasMaxLength(35)
                        .HasColumnType("integer");

                    b.HasKey("IDTasa");

                    b.ToTable("Tasas", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.TipoArchivos", b =>
                {
                    b.Property<int>("IDTipoarch")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDTipoarch"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.HasKey("IDTipoarch");

                    b.ToTable("TipoArchivos", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.TipoMovimiento", b =>
                {
                    b.Property<int>("IDTipo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(35)
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IDTipo"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.HasKey("IDTipo");

                    b.ToTable("TipoMovimientos", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Usuario", b =>
                {
                    b.Property<int>("CI")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(35)
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CI"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.Property<DateTime>("FechaDenacimiento")
                        .HasMaxLength(35)
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.Property<int>("Telefono")
                        .HasMaxLength(35)
                        .HasColumnType("integer");

                    b.HasKey("CI");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Archivos", b =>
                {
                    b.HasOne("Core.Entidades.Prestamos", "Prestamo")
                        .WithMany()
                        .HasForeignKey("IDPrestamo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entidades.TipoArchivos", "TipoArchivo")
                        .WithMany()
                        .HasForeignKey("IDTipoarch")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestamo");

                    b.Navigation("TipoArchivo");
                });

            modelBuilder.Entity("Core.Entidades.Archivos_Prestamos", b =>
                {
                    b.HasOne("Core.Entidades.Archivos", "Archivo")
                        .WithMany()
                        .HasForeignKey("IDArchivo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entidades.Prestamos", "Prestamo")
                        .WithMany()
                        .HasForeignKey("IDPrestamo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Archivo");

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("Core.Entidades.Cuentas", b =>
                {
                    b.HasOne("Core.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("CI")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Core.Entidades.Cuotas", b =>
                {
                    b.HasOne("Core.Entidades.Prestamos", "Prestamo")
                        .WithMany()
                        .HasForeignKey("IDPrestamo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("Core.Entidades.Movimientos", b =>
                {
                    b.HasOne("Core.Entidades.Cuentas", "CuentaAcreditada")
                        .WithMany()
                        .HasForeignKey("IDCuentaAcreditada")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entidades.Cuentas", "CuentaDebitada")
                        .WithMany()
                        .HasForeignKey("IDCuentaDebitada")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entidades.TipoMovimiento", "Tipo")
                        .WithMany()
                        .HasForeignKey("IDTipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CuentaAcreditada");

                    b.Navigation("CuentaDebitada");

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("Core.Entidades.Prestamos", b =>
                {
                    b.HasOne("Core.Entidades.Cuentas", "Cuenta")
                        .WithMany()
                        .HasForeignKey("IDCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entidades.Tasas", "Tasa")
                        .WithMany()
                        .HasForeignKey("IDTasa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");

                    b.Navigation("Tasa");
                });

            modelBuilder.Entity("Core.Entidades.Sesion", b =>
                {
                    b.HasOne("Core.Entidades.Usuario", "UsuarioActual")
                        .WithMany()
                        .HasForeignKey("CedulaUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioActual");
                });
#pragma warning restore 612, 618
        }
    }
}
