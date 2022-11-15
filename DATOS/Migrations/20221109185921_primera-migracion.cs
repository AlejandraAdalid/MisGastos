using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATOS.Migrations
{
    /// <inheritdoc />
    public partial class primeramigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjetivosDeAhorros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivosDeAhorros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ahorros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMovimiento = table.Column<int>(type: "int", nullable: false),
                    ObjetivosDeAhorroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ahorros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ahorros_ObjetivosDeAhorros_ObjetivosDeAhorroId",
                        column: x => x.ObjetivosDeAhorroId,
                        principalTable: "ObjetivosDeAhorros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsFijo = table.Column<bool>(type: "bit", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: true),
                    IdAhorro = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimientos_Ahorros_IdAhorro",
                        column: x => x.IdAhorro,
                        principalTable: "Ahorros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movimientos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ahorros_IdMovimiento",
                table: "Ahorros",
                column: "IdMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Ahorros_ObjetivosDeAhorroId",
                table: "Ahorros",
                column: "ObjetivosDeAhorroId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_IdAhorro",
                table: "Movimientos",
                column: "IdAhorro");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_IdCategoria",
                table: "Movimientos",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Ahorros_Movimientos_IdMovimiento",
                table: "Ahorros",
                column: "IdMovimiento",
                principalTable: "Movimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ahorros_Movimientos_IdMovimiento",
                table: "Ahorros");

            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Ahorros");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "ObjetivosDeAhorros");
        }
    }
}
