using Microsoft.EntityFrameworkCore.Migrations;

namespace VeterinariaProject.Migrations
{
    public partial class MapMascota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Mascotas",
                newName: "Mascotas",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "dbo",
                table: "Mascotas",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Mascotas",
                schema: "dbo",
                newName: "Mascotas");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Mascotas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);
        }
    }
}
