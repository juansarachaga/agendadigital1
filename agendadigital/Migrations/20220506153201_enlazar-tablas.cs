using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agendadigital.Migrations
{
    public partial class enlazartablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "contactoId",
                table: "Telefonos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Contactos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_contactoId",
                table: "Telefonos",
                column: "contactoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_usuarioId",
                table: "Contactos",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_Usuarios_usuarioId",
                table: "Contactos",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefonos_Contactos_contactoId",
                table: "Telefonos",
                column: "contactoId",
                principalTable: "Contactos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contactos_Usuarios_usuarioId",
                table: "Contactos");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefonos_Contactos_contactoId",
                table: "Telefonos");

            migrationBuilder.DropIndex(
                name: "IX_Telefonos_contactoId",
                table: "Telefonos");

            migrationBuilder.DropIndex(
                name: "IX_Contactos_usuarioId",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "contactoId",
                table: "Telefonos");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Contactos");
        }
    }
}
