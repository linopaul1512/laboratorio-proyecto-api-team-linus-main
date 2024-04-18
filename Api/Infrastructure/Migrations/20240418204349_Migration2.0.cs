using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasas",
                columns: table => new
                {
                    IDTasa = table.Column<int>(type: "integer", maxLength: 5, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Porcentaje = table.Column<int>(type: "integer", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasas", x => x.IDTasa);
                });

            migrationBuilder.CreateTable(
                name: "TipoArchivos",
                columns: table => new
                {
                    IDTipoarch = table.Column<int>(type: "integer", maxLength: 2, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    Estado = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoArchivos", x => x.IDTipoarch);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimientos",
                columns: table => new
                {
                    IDTipo = table.Column<int>(type: "integer", maxLength: 35, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimientos", x => x.IDTipo);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CI = table.Column<int>(type: "integer", maxLength: 35, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    Apellido = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    FechaDenacimiento = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 35, nullable: false),
                    Telefono = table.Column<int>(type: "integer", maxLength: 35, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    Direccion = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    Contraseña = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CI);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    IDCuenta = table.Column<int>(type: "integer", maxLength: 35, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CI = table.Column<int>(type: "integer", nullable: false),
                    Saldo = table.Column<int>(type: "integer", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.IDCuenta);
                    table.ForeignKey(
                        name: "FK_Cuentas_Usuarios_CI",
                        column: x => x.CI,
                        principalTable: "Usuarios",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "character varying(227)", maxLength: 227, nullable: false),
                    CedulaUsuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sesiones_Usuarios_CedulaUsuario",
                        column: x => x.CedulaUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    IDMovimiento = table.Column<int>(type: "integer", maxLength: 35, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IDTipo = table.Column<int>(type: "integer", nullable: false),
                    IDCuentaAcreditada = table.Column<int>(type: "integer", nullable: false),
                    IDCuentaDebitada = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 35, nullable: false),
                    Monto = table.Column<double>(type: "double precision", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.IDMovimiento);
                    table.ForeignKey(
                        name: "FK_Movimientos_Cuentas_IDCuentaAcreditada",
                        column: x => x.IDCuentaAcreditada,
                        principalTable: "Cuentas",
                        principalColumn: "IDCuenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimientos_Cuentas_IDCuentaDebitada",
                        column: x => x.IDCuentaDebitada,
                        principalTable: "Cuentas",
                        principalColumn: "IDCuenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimientos_TipoMovimientos_IDTipo",
                        column: x => x.IDTipo,
                        principalTable: "TipoMovimientos",
                        principalColumn: "IDTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    IDPrestamo = table.Column<int>(type: "integer", maxLength: 35, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CantCuotas = table.Column<int>(type: "integer", maxLength: 35, nullable: false),
                    IDTasa = table.Column<int>(type: "integer", nullable: false),
                    IDCuenta = table.Column<int>(type: "integer", nullable: false),
                    FechaDeOperacion = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 35, nullable: false),
                    Monto = table.Column<double>(type: "double precision", maxLength: 35, nullable: false),
                    Estado = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.IDPrestamo);
                    table.ForeignKey(
                        name: "FK_Prestamos_Cuentas_IDCuenta",
                        column: x => x.IDCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "IDCuenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Tasas_IDTasa",
                        column: x => x.IDTasa,
                        principalTable: "Tasas",
                        principalColumn: "IDTasa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Archivos",
                columns: table => new
                {
                    IDArchivo = table.Column<int>(type: "integer", maxLength: 10, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IDPrestamo = table.Column<int>(type: "integer", nullable: false),
                    IDTipoarch = table.Column<int>(type: "integer", nullable: false),
                    Documento = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos", x => x.IDArchivo);
                    table.ForeignKey(
                        name: "FK_Archivos_Prestamos_IDPrestamo",
                        column: x => x.IDPrestamo,
                        principalTable: "Prestamos",
                        principalColumn: "IDPrestamo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Archivos_TipoArchivos_IDTipoarch",
                        column: x => x.IDTipoarch,
                        principalTable: "TipoArchivos",
                        principalColumn: "IDTipoarch",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    IDCuota = table.Column<int>(type: "integer", maxLength: 35, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IDPrestamo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => x.IDCuota);
                    table.ForeignKey(
                        name: "FK_Cuotas_Prestamos_IDPrestamo",
                        column: x => x.IDPrestamo,
                        principalTable: "Prestamos",
                        principalColumn: "IDPrestamo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Archivos_Prestamos",
                columns: table => new
                {
                    IDArchpres = table.Column<int>(type: "integer", maxLength: 10, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IDArchivo = table.Column<int>(type: "integer", nullable: false),
                    IDPrestamo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos_Prestamos", x => x.IDArchpres);
                    table.ForeignKey(
                        name: "FK_Archivos_Prestamos_Archivos_IDArchivo",
                        column: x => x.IDArchivo,
                        principalTable: "Archivos",
                        principalColumn: "IDArchivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Archivos_Prestamos_Prestamos_IDPrestamo",
                        column: x => x.IDPrestamo,
                        principalTable: "Prestamos",
                        principalColumn: "IDPrestamo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_IDPrestamo",
                table: "Archivos",
                column: "IDPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_IDTipoarch",
                table: "Archivos",
                column: "IDTipoarch");

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_Prestamos_IDArchivo",
                table: "Archivos_Prestamos",
                column: "IDArchivo");

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_Prestamos_IDPrestamo",
                table: "Archivos_Prestamos",
                column: "IDPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_CI",
                table: "Cuentas",
                column: "CI");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_IDPrestamo",
                table: "Cuotas",
                column: "IDPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_IDCuentaAcreditada",
                table: "Movimientos",
                column: "IDCuentaAcreditada");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_IDCuentaDebitada",
                table: "Movimientos",
                column: "IDCuentaDebitada");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_IDTipo",
                table: "Movimientos",
                column: "IDTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IDCuenta",
                table: "Prestamos",
                column: "IDCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IDTasa",
                table: "Prestamos",
                column: "IDTasa");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_CedulaUsuario",
                table: "Sesiones",
                column: "CedulaUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archivos_Prestamos");

            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Archivos");

            migrationBuilder.DropTable(
                name: "TipoMovimientos");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "TipoArchivos");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Tasas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
