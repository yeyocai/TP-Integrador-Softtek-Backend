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
                name: "Roles",
                columns: table => new
                {
                    codRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.codRol);
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    codUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    dni = table.Column<int>(type: "INT", nullable: false),
                    tipo = table.Column<byte>(type: "TINYINT", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    contrasenia = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    fechaBaja = table.Column<DateTime>(type: "DATE", nullable: true),
                    rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.codUsuario);
                    table.ForeignKey(
                        name: "FK_Users_Roles_rol",
                        column: x => x.rol,
                        principalTable: "Roles",
                        principalColumn: "codRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "codProyecto", "direccion", "fechaBaja", "nombre", "estado" },
                values: new object[,]
                {
                    { 5, "Salta 123", new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Extracción de minerales", (byte)3 },
                    { 10, "Humberto Primo 123", null, "Extracción de gas en Vaca Muerta", (byte)1 },
                    { 30, "Almafuerte 256", null, "Creación de gasoducto Nestor Kirchner", (byte)2 },
                    { 50, "Machado 255", null, "Extracción de petóleo en Vaca Muerta", (byte)3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "codRol", "activo", "descripcion", "nombre" },
                values: new object[,]
                {
                    { 1, true, "Administrador", "Administrador" },
                    { 2, true, "Consultor", "Consultor" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "codServicio", "descr", "valorHora", "estado" },
                values: new object[,]
                {
                    { 1, "Servicio de soldadura de caños", 25700.25m, true },
                    { 2, "Servicio de instalación de gasoducto", 35800.7m, true },
                    { 3, "Servicio de sellado de pérdidas", 10500.9m, false }
                });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "codTrabajo", "costo", "fecha", "fechaBaja", "valorHora", "cantHoras", "codProyecto", "codServicio" },
                values: new object[,]
                {
                    { 10500, 45272.25m, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5030.25m, 9, 10, 1 },
                    { 13400, 54003.6m, new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4500.3m, 12, 30, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "codUsuario", "fechaBaja", "dni", "email", "nombre", "contrasenia", "rol", "tipo" },
                values: new object[] { 1010, null, 11222333, "juan.perez@gmail.com", "Juan Perez", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", 1, (byte)1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "codUsuario", "fechaBaja", "dni", "email", "nombre", "contrasenia", "rol", "tipo" },
                values: new object[] { 2020, null, 22111555, "maria.lopez@gmail.com", "Maria Lopez", "edee29f882543b956620b26d0ee0e7e950399b1c4222f5de05e06425b4c995e9", 2, (byte)2 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_rol",
                table: "Users",
                column: "rol");
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

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
