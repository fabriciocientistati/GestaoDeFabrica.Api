using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FabricaGestao.Api.Migrations
{
    /// <inheritdoc />
    public partial class Criacao_tabela_usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBUsuarios",
                columns: table => new
                {
                    UsuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuLogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuSenha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuIncPor = table.Column<int>(type: "int", nullable: false),
                    UsuIncEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuAltPor = table.Column<int>(type: "int", nullable: true),
                    UsuAltEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBUsuarios", x => x.UsuId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBUsuarios");
        }
    }
}
