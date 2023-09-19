using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_Integrador_Softtek_Backend.Migrations
{
    public partial class TechOil3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Users",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "codUsuario",
                keyValue: 1010,
                column: "email",
                value: "juan.perez@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "codUsuario",
                keyValue: 2020,
                column: "email",
                value: "maria.lopez@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Users");
        }
    }
}
