using Microsoft.EntityFrameworkCore.Migrations;

namespace VeterinariaProject.Migrations
{
    public partial class AgregandoRazaIdEnMascota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RazaId",
                schema: "dbo",
                table: "Mascotas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RazaId",
                schema: "dbo",
                table: "Mascotas");
        }
    }
}
