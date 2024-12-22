using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FabricaGestao.Api.Migrations
{
    /// <inheritdoc />
    public partial class Criacao_tabela_perfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerId",
                table: "TBUsuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PerfilModelo",
                columns: table => new
                {
                    PerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerIncPor = table.Column<int>(type: "int", nullable: false),
                    PerIncEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerAltPor = table.Column<int>(type: "int", nullable: false),
                    PerAltEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilModelo", x => x.PerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBUsuarios_PerId",
                table: "TBUsuarios",
                column: "PerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBUsuarios_PerfilModelo_PerId",
                table: "TBUsuarios",
                column: "PerId",
                principalTable: "PerfilModelo",
                principalColumn: "PerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBUsuarios_PerfilModelo_PerId",
                table: "TBUsuarios");

            migrationBuilder.DropTable(
                name: "PerfilModelo");

            migrationBuilder.DropIndex(
                name: "IX_TBUsuarios_PerId",
                table: "TBUsuarios");

            migrationBuilder.DropColumn(
                name: "PerId",
                table: "TBUsuarios");
        }
    }
}
