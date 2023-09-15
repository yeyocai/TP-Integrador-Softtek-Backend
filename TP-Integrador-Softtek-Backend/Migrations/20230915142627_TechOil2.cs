using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_Integrador_Softtek_Backend.Migrations
{
    public partial class TechOil2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "codProyecto",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "codProyecto",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "codProyecto",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "codProyecto",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "codServicio",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "codServicio",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "codServicio",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "codTrabajo",
                keyValue: 10500);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "codTrabajo",
                keyValue: 13400);
        }
    }
}
