using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SueldoBase = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_color", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "forma_pago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forma_pago", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genero", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "insumo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorUnit = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    StockMin = table.Column<int>(type: "int", nullable: false),
                    StockMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insumo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    rolName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "talla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_talla", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_estado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_persona", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_proteccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_proteccion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPaisFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamento_pais_IdPaisFk",
                        column: x => x.IdPaisFk,
                        principalTable: "pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoEstadoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estado_tipo_estado_IdTipoEstadoFk",
                        column: x => x.IdTipoEstadoFk,
                        principalTable: "tipo_estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRole", x => new { x.UserId, x.RolId });
                    table.ForeignKey(
                        name: "FK_userRole_role_RolId",
                        column: x => x.RolId,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRole_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "municipio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDeptoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_municipio_Departamento_IdDeptoFk",
                        column: x => x.IdDeptoFk,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "prenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPrenda = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorUnitCop = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorUnitUsd = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IdTipoProteccionFk = table.Column<int>(type: "int", nullable: false),
                    IdEstadoFk = table.Column<int>(type: "int", nullable: false),
                    IdGeneroFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prenda_estado_IdEstadoFk",
                        column: x => x.IdEstadoFk,
                        principalTable: "estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prenda_genero_IdGeneroFk",
                        column: x => x.IdGeneroFk,
                        principalTable: "genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prenda_tipo_proteccion_IdTipoProteccionFk",
                        column: x => x.IdTipoProteccionFk,
                        principalTable: "tipo_proteccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCliente = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoPersonaFk = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    IdMunicipioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cliente_municipio_IdMunicipioFk",
                        column: x => x.IdMunicipioFk,
                        principalTable: "municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cliente_tipo_persona_IdTipoPersonaFk",
                        column: x => x.IdTipoPersonaFk,
                        principalTable: "tipo_persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEmpleado = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCargoFk = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateOnly>(type: "date", nullable: false),
                    IdMunicipioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_empleado_cargo_IdCargoFk",
                        column: x => x.IdCargoFk,
                        principalTable: "cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empleado_municipio_IdMunicipioFk",
                        column: x => x.IdMunicipioFk,
                        principalTable: "municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RazonSocial = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    RepresentanteLegal = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdMunicipioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_empresa_municipio_IdMunicipioFk",
                        column: x => x.IdMunicipioFk,
                        principalTable: "municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NitProveedor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdMunicipioFk = table.Column<int>(type: "int", nullable: false),
                    IdTipoPersonaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proveedor_municipio_IdMunicipioFk",
                        column: x => x.IdMunicipioFk,
                        principalTable: "municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_proveedor_tipo_persona_IdTipoPersonaFk",
                        column: x => x.IdTipoPersonaFk,
                        principalTable: "tipo_persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "insumo_prenda",
                columns: table => new
                {
                    IdInsumoFk = table.Column<int>(type: "int", nullable: false),
                    IdPrendaFk = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insumo_prenda", x => new { x.IdPrendaFk, x.IdInsumoFk });
                    table.ForeignKey(
                        name: "FK_insumo_prenda_insumo_IdInsumoFk",
                        column: x => x.IdInsumoFk,
                        principalTable: "insumo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insumo_prenda_prenda_IdPrendaFk",
                        column: x => x.IdPrendaFk,
                        principalTable: "prenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodInventario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPrendaFk = table.Column<int>(type: "int", nullable: false),
                    ValorVtaCop = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorVtaUsd = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventario_prenda_IdPrendaFk",
                        column: x => x.IdPrendaFk,
                        principalTable: "prenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdEmpleadoFk = table.Column<int>(type: "int", nullable: false),
                    IdClienteFk = table.Column<int>(type: "int", nullable: false),
                    IdEstadoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orden_cliente_IdClienteFk",
                        column: x => x.IdClienteFk,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orden_empleado_IdEmpleadoFk",
                        column: x => x.IdEmpleadoFk,
                        principalTable: "empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orden_estado_IdEstadoFk",
                        column: x => x.IdEstadoFk,
                        principalTable: "estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdEmpleadoFk = table.Column<int>(type: "int", nullable: false),
                    IdClienteFk = table.Column<int>(type: "int", nullable: false),
                    IdFormaPagoFK = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_venta_cliente_IdClienteFk",
                        column: x => x.IdClienteFk,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_venta_empleado_IdEmpleadoFk",
                        column: x => x.IdEmpleadoFk,
                        principalTable: "empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_venta_forma_pago_IdFormaPagoFK",
                        column: x => x.IdFormaPagoFK,
                        principalTable: "forma_pago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "insumo_proveedor",
                columns: table => new
                {
                    IdInsumoFk = table.Column<int>(type: "int", nullable: false),
                    IdProveedorFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insumo_proveedor", x => new { x.IdProveedorFk, x.IdInsumoFk });
                    table.ForeignKey(
                        name: "FK_insumo_proveedor_insumo_IdInsumoFk",
                        column: x => x.IdInsumoFk,
                        principalTable: "insumo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insumo_proveedor_proveedor_IdProveedorFk",
                        column: x => x.IdProveedorFk,
                        principalTable: "proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inventario_talla",
                columns: table => new
                {
                    IdInventarioFK = table.Column<int>(type: "int", nullable: false),
                    IdTallaFk = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventario_talla", x => new { x.IdTallaFk, x.IdInventarioFK });
                    table.ForeignKey(
                        name: "FK_inventario_talla_inventario_IdInventarioFK",
                        column: x => x.IdInventarioFK,
                        principalTable: "inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventario_talla_talla_IdTallaFk",
                        column: x => x.IdTallaFk,
                        principalTable: "talla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detalle_orden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdOrdenFk = table.Column<int>(type: "int", nullable: false),
                    IdPrendaFk = table.Column<int>(type: "int", nullable: false),
                    CantidadProducir = table.Column<int>(type: "int", nullable: false),
                    IdColorFk = table.Column<int>(type: "int", nullable: false),
                    CantidadProducida = table.Column<int>(type: "int", nullable: false),
                    IdEstadoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_orden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalle_orden_color_IdColorFk",
                        column: x => x.IdColorFk,
                        principalTable: "color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_orden_estado_IdEstadoFk",
                        column: x => x.IdEstadoFk,
                        principalTable: "estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_orden_orden_IdOrdenFk",
                        column: x => x.IdOrdenFk,
                        principalTable: "orden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_orden_prenda_IdPrendaFk",
                        column: x => x.IdPrendaFk,
                        principalTable: "prenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detalle_venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdVentaFk = table.Column<int>(type: "int", nullable: false),
                    IdInventarioFK = table.Column<int>(type: "int", nullable: false),
                    IdTallaFk = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ValorUnit = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_venta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalle_venta_inventario_IdInventarioFK",
                        column: x => x.IdInventarioFK,
                        principalTable: "inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_venta_talla_IdTallaFk",
                        column: x => x.IdTallaFk,
                        principalTable: "talla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_venta_venta_IdVentaFk",
                        column: x => x.IdVentaFk,
                        principalTable: "venta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "cargo",
                columns: new[] { "Id", "Descripcion", "SueldoBase" },
                values: new object[,]
                {
                    { 1, "Supervisor", 0m },
                    { 2, "Cajero", 0m }
                });

            migrationBuilder.InsertData(
                table: "color",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Rojo" },
                    { 2, "Azul" },
                    { 3, "Amarillo" },
                    { 4, "Verde" }
                });

            migrationBuilder.InsertData(
                table: "forma_pago",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Efectivo" },
                    { 2, "Tarjeta Credito" },
                    { 3, "Tarjeta Debito" }
                });

            migrationBuilder.InsertData(
                table: "genero",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Masculino" },
                    { 2, "Femenino" }
                });

            migrationBuilder.InsertData(
                table: "insumo",
                columns: new[] { "Id", "Nombre", "StockMax", "StockMin", "ValorUnit" },
                values: new object[] { 1, "Botones", 20, 10, 12000m });

            migrationBuilder.InsertData(
                table: "pais",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Colombia" });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "rolName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "talla",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "S" },
                    { 2, "M" },
                    { 3, "L" },
                    { 4, "XL" }
                });

            migrationBuilder.InsertData(
                table: "tipo_estado",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Produccion" },
                    { 2, "Terminado" }
                });

            migrationBuilder.InsertData(
                table: "tipo_persona",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Persona Natural" },
                    { 2, "Persona Juridica" }
                });

            migrationBuilder.InsertData(
                table: "tipo_proteccion",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Completa" },
                    { 2, "Tipo 2" }
                });

            migrationBuilder.InsertData(
                table: "Departamento",
                columns: new[] { "Id", "IdPaisFk", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Santander" },
                    { 2, 1, "Antioquia" },
                    { 3, 1, "Boyaca" },
                    { 4, 1, "Magdalena" }
                });

            migrationBuilder.InsertData(
                table: "estado",
                columns: new[] { "Id", "Descripcion", "IdTipoEstadoFk" },
                values: new object[] { 1, "Produccion", 1 });

            migrationBuilder.InsertData(
                table: "municipio",
                columns: new[] { "Id", "IdDeptoFk", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Bucaramanga" },
                    { 2, 1, "San Gil" },
                    { 3, 2, "Medellin" }
                });

            migrationBuilder.InsertData(
                table: "prenda",
                columns: new[] { "Id", "IdEstadoFk", "IdGeneroFk", "IdPrenda", "IdTipoProteccionFk", "Nombre", "ValorUnitCop", "ValorUnitUsd" },
                values: new object[,]
                {
                    { 1, 1, 1, "2343", 1, "Camiseta Hombre", 100000m, 25m },
                    { 2, 1, 2, "2342343", 1, "Camiseta Mujer", 100000m, 25m }
                });

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "Id", "FechaRegistro", "IdCliente", "IdMunicipioFk", "IdTipoPersonaFk", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 5, 22), "1101622982", 1, 1, "Nicolas" },
                    { 2, new DateOnly(2023, 4, 22), "113451682", 2, 1, "Paco" }
                });

            migrationBuilder.InsertData(
                table: "empleado",
                columns: new[] { "Id", "FechaIngreso", "IdCargoFk", "IdEmpleado", "IdMunicipioFk", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateOnly(2021, 4, 12), 1, "1234324", 2, "Juan Carlos" },
                    { 2, new DateOnly(2023, 1, 12), 2, "44444", 1, "Paco" },
                    { 3, new DateOnly(2022, 9, 20), 1, "3432", 2, "David" }
                });

            migrationBuilder.InsertData(
                table: "empresa",
                columns: new[] { "Id", "FechaCreacion", "IdMunicipioFk", "Nit", "RazonSocial", "RepresentanteLegal" },
                values: new object[,]
                {
                    { 1, new DateOnly(2013, 11, 22), 1, "12321423", "asdfdasf", "Paco" },
                    { 2, new DateOnly(2020, 11, 22), 2, "3433423", "dsfdsfsda", "Pedro" }
                });

            migrationBuilder.InsertData(
                table: "insumo_prenda",
                columns: new[] { "IdInsumoFk", "IdPrendaFk", "Cantidad" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "inventario",
                columns: new[] { "Id", "CodInventario", "IdPrendaFk", "ValorVtaCop", "ValorVtaUsd" },
                values: new object[] { 1, "123", 1, 40000m, 10m });

            migrationBuilder.InsertData(
                table: "proveedor",
                columns: new[] { "Id", "IdMunicipioFk", "IdTipoPersonaFk", "NitProveedor", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, 1, "23423", "distriRopa" },
                    { 2, 2, 1, "445332", "multiRopa" }
                });

            migrationBuilder.InsertData(
                table: "insumo_proveedor",
                columns: new[] { "IdInsumoFk", "IdProveedorFk" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "inventario_talla",
                columns: new[] { "IdInventarioFK", "IdTallaFk", "Cantidad" },
                values: new object[] { 1, 1, 10 });

            migrationBuilder.InsertData(
                table: "orden",
                columns: new[] { "Id", "Fecha", "IdClienteFk", "IdEmpleadoFk", "IdEstadoFk" },
                values: new object[] { 1, new DateTime(2023, 10, 21, 2, 53, 44, 519, DateTimeKind.Utc).AddTicks(9637), 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "venta",
                columns: new[] { "Id", "Fecha", "IdClienteFk", "IdEmpleadoFk", "IdFormaPagoFK", "Total" },
                values: new object[] { 1, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 20000.0 });

            migrationBuilder.InsertData(
                table: "detalle_orden",
                columns: new[] { "Id", "CantidadProducida", "CantidadProducir", "IdColorFk", "IdEstadoFk", "IdOrdenFk", "IdPrendaFk" },
                values: new object[,]
                {
                    { 1, 3, 10, 1, 1, 1, 1 },
                    { 2, 5, 6, 2, 1, 1, 1 },
                    { 3, 10, 20, 4, 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "detalle_venta",
                columns: new[] { "Id", "Cantidad", "IdInventarioFK", "IdTallaFk", "IdVentaFk", "ValorUnit" },
                values: new object[,]
                {
                    { 1, 2, 1, 1, 1, 50000m },
                    { 2, 1, 1, 2, 1, 5000m },
                    { 3, 1, 1, 2, 1, 10000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_IdCliente",
                table: "cliente",
                column: "IdCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cliente_IdMunicipioFk",
                table: "cliente",
                column: "IdMunicipioFk");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_IdTipoPersonaFk",
                table: "cliente",
                column: "IdTipoPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_IdPaisFk",
                table: "Departamento",
                column: "IdPaisFk");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_IdColorFk",
                table: "detalle_orden",
                column: "IdColorFk");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_IdEstadoFk",
                table: "detalle_orden",
                column: "IdEstadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_IdOrdenFk",
                table: "detalle_orden",
                column: "IdOrdenFk");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_IdPrendaFk",
                table: "detalle_orden",
                column: "IdPrendaFk");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_venta_IdInventarioFK",
                table: "detalle_venta",
                column: "IdInventarioFK");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_venta_IdTallaFk",
                table: "detalle_venta",
                column: "IdTallaFk");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_venta_IdVentaFk",
                table: "detalle_venta",
                column: "IdVentaFk");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_IdCargoFk",
                table: "empleado",
                column: "IdCargoFk");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_IdEmpleado",
                table: "empleado",
                column: "IdEmpleado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_empleado_IdMunicipioFk",
                table: "empleado",
                column: "IdMunicipioFk");

            migrationBuilder.CreateIndex(
                name: "IX_empresa_IdMunicipioFk",
                table: "empresa",
                column: "IdMunicipioFk");

            migrationBuilder.CreateIndex(
                name: "IX_empresa_Nit",
                table: "empresa",
                column: "Nit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estado_IdTipoEstadoFk",
                table: "estado",
                column: "IdTipoEstadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_insumo_Nombre",
                table: "insumo",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_insumo_prenda_IdInsumoFk",
                table: "insumo_prenda",
                column: "IdInsumoFk");

            migrationBuilder.CreateIndex(
                name: "IX_insumo_proveedor_IdInsumoFk",
                table: "insumo_proveedor",
                column: "IdInsumoFk");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_CodInventario",
                table: "inventario",
                column: "CodInventario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventario_IdPrendaFk",
                table: "inventario",
                column: "IdPrendaFk");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_talla_IdInventarioFK",
                table: "inventario_talla",
                column: "IdInventarioFK");

            migrationBuilder.CreateIndex(
                name: "IX_municipio_IdDeptoFk",
                table: "municipio",
                column: "IdDeptoFk");

            migrationBuilder.CreateIndex(
                name: "IX_orden_IdClienteFk",
                table: "orden",
                column: "IdClienteFk");

            migrationBuilder.CreateIndex(
                name: "IX_orden_IdEmpleadoFk",
                table: "orden",
                column: "IdEmpleadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_orden_IdEstadoFk",
                table: "orden",
                column: "IdEstadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_prenda_IdEstadoFk",
                table: "prenda",
                column: "IdEstadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_prenda_IdGeneroFk",
                table: "prenda",
                column: "IdGeneroFk");

            migrationBuilder.CreateIndex(
                name: "IX_prenda_IdPrenda",
                table: "prenda",
                column: "IdPrenda",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prenda_IdTipoProteccionFk",
                table: "prenda",
                column: "IdTipoProteccionFk");

            migrationBuilder.CreateIndex(
                name: "IX_proveedor_IdMunicipioFk",
                table: "proveedor",
                column: "IdMunicipioFk");

            migrationBuilder.CreateIndex(
                name: "IX_proveedor_IdTipoPersonaFk",
                table: "proveedor",
                column: "IdTipoPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_proveedor_NitProveedor",
                table: "proveedor",
                column: "NitProveedor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_talla_Descripcion",
                table: "talla",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userRole_RolId",
                table: "userRole",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_venta_IdClienteFk",
                table: "venta",
                column: "IdClienteFk");

            migrationBuilder.CreateIndex(
                name: "IX_venta_IdEmpleadoFk",
                table: "venta",
                column: "IdEmpleadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_venta_IdFormaPagoFK",
                table: "venta",
                column: "IdFormaPagoFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_orden");

            migrationBuilder.DropTable(
                name: "detalle_venta");

            migrationBuilder.DropTable(
                name: "empresa");

            migrationBuilder.DropTable(
                name: "insumo_prenda");

            migrationBuilder.DropTable(
                name: "insumo_proveedor");

            migrationBuilder.DropTable(
                name: "inventario_talla");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "userRole");

            migrationBuilder.DropTable(
                name: "color");

            migrationBuilder.DropTable(
                name: "orden");

            migrationBuilder.DropTable(
                name: "venta");

            migrationBuilder.DropTable(
                name: "insumo");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "inventario");

            migrationBuilder.DropTable(
                name: "talla");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "empleado");

            migrationBuilder.DropTable(
                name: "forma_pago");

            migrationBuilder.DropTable(
                name: "prenda");

            migrationBuilder.DropTable(
                name: "tipo_persona");

            migrationBuilder.DropTable(
                name: "cargo");

            migrationBuilder.DropTable(
                name: "municipio");

            migrationBuilder.DropTable(
                name: "estado");

            migrationBuilder.DropTable(
                name: "genero");

            migrationBuilder.DropTable(
                name: "tipo_proteccion");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "tipo_estado");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}
