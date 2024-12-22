using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FabricaGestao.Api.Migrations
{
    /// <inheritdoc />
    public partial class Correcao_contexto_nome_TBPerfis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBUsuarios_PerfilModelo_PerId",
                table: "TBUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfilModelo",
                table: "PerfilModelo");

            migrationBuilder.RenameTable(
                name: "PerfilModelo",
                newName: "TBPerfis");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBPerfis",
                table: "TBPerfis",
                column: "PerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBUsuarios_TBPerfis_PerId",
                table: "TBUsuarios",
                column: "PerId",
                principalTable: "TBPerfis",
                principalColumn: "PerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBUsuarios_TBPerfis_PerId",
                table: "TBUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBPerfis",
                table: "TBPerfis");

            migrationBuilder.RenameTable(
                name: "TBPerfis",
                newName: "PerfilModelo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfilModelo",
                table: "PerfilModelo",
                column: "PerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBUsuarios_PerfilModelo_PerId",
                table: "TBUsuarios",
                column: "PerId",
                principalTable: "PerfilModelo",
                principalColumn: "PerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
