using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_Integrador_Softtek_Backend.Migrations
{
    public partial class TechOil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    codProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    direccion = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    estado = table.Column<byte>(type: "TINYINT", nullable: false),
                    fechaBaja = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.codProyecto);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    codServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descr = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    estado = table.Column<bool>(type: "BIT", nullable: false),
                    valorHora = table.Column<decimal>(type: "NUMERIC(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.codServicio);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    codUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    dni = table.Column<int>(type: "INT", nullable: false),
                    tipo = table.Column<byte>(type: "TINYINT", nullable: false),
                    contrasenia = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    fechaBaja = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.codUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    codTrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "DATE", nullable: false),
                    codProyecto = table.Column<int>(type: "INT", nullable: false),
                    codServicio = table.Column<int>(type: "INT", nullable: false),
                    cantHoras = table.Column<int>(type: "INT", nullable: false),
                    valorHora = table.Column<decimal>(type: "NUMERIC(8,2)", nullable: false),
                    costo = table.Column<decimal>(type: "NUMERIC(10,2)", nullable: false),
                    fechaBaja = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.codTrabajo);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "codUsuario", "fechaBaja", "dni", "nombre", "contrasenia", "tipo" },
                values: new object[] { 1010, null, 11222333, "Juan Perez", "1234", (byte)1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "codUsuario", "fechaBaja", "dni", "nombre", "contrasenia", "tipo" },
                values: new object[] { 2020, null, 22111555, "Maria Lopez", "2222", (byte)2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Works");
        }
    }
}
