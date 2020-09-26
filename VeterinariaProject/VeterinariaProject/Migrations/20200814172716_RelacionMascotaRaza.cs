using Microsoft.EntityFrameworkCore.Migrations;

namespace VeterinariaProject.Migrations
{
    public partial class RelacionMascotaRaza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_RazaId",
                schema: "dbo",
                table: "Mascotas",
                column: "RazaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Razas_RazaId",
                schema: "dbo",
                table: "Mascotas",
                column: "RazaId",
                principalTable: "Razas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Razas_RazaId",
                schema: "dbo",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_RazaId",
                schema: "dbo",
                table: "Mascotas");
        }
    }
}
