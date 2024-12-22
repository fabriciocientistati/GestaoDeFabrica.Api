using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FabricaGestao.Api.Migrations
{
    /// <inheritdoc />
    public partial class Criacaobancodedados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCategorias",
                columns: table => new
                {
                    CatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatIncPor = table.Column<int>(type: "int", nullable: false),
                    CatIncEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CatAltPor = table.Column<int>(type: "int", nullable: true),
                    CatAltEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCategorias", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "TBPessoas",
                columns: table => new
                {
                    PesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PesNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesCpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesCnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesNumCelular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesNumTelefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesCep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesRua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesNumero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesBairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesCidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesEstado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesIncPor = table.Column<int>(type: "int", nullable: false),
                    PesIncEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PesAltPor = table.Column<int>(type: "int", nullable: true),
                    PesAltEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPessoas", x => x.PesId);
                });

            migrationBuilder.CreateTable(
                name: "TBProdutos",
                columns: table => new
                {
                    ProId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatId = table.Column<int>(type: "int", nullable: false),
                    ProNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProPreco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProQuantidadeEmEstoque = table.Column<int>(type: "int", nullable: false),
                    ProImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProIncPor = table.Column<int>(type: "int", nullable: false),
                    ProIncEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProAltPor = table.Column<int>(type: "int", nullable: true),
                    ProAltEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBProdutos", x => x.ProId);
                    table.ForeignKey(
                        name: "FK_TBProdutos_TBCategorias_CatId",
                        column: x => x.CatId,
                        principalTable: "TBCategorias",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBOrcamentos",
                columns: table => new
                {
                    OrcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PesId = table.Column<int>(type: "int", nullable: false),
                    OrcDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrcObservacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrcPreco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrcTipoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrcTipoEntrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrcIncPor = table.Column<int>(type: "int", nullable: false),
                    OrcIncEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrcAltPor = table.Column<int>(type: "int", nullable: true),
                    OrcAltEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBOrcamentos", x => x.OrcId);
                    table.ForeignKey(
                        name: "FK_TBOrcamentos_TBPessoas_PesId",
                        column: x => x.PesId,
                        principalTable: "TBPessoas",
                        principalColumn: "PesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBOrcamentoProdutos",
                columns: table => new
                {
                    OrcId = table.Column<int>(type: "int", nullable: false),
                    ProId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBOrcamentoProdutos", x => new { x.OrcId, x.ProId });
                    table.ForeignKey(
                        name: "FK_TBOrcamentoProdutos_TBOrcamentos_OrcId",
                        column: x => x.OrcId,
                        principalTable: "TBOrcamentos",
                        principalColumn: "OrcId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBOrcamentoProdutos_TBProdutos_ProId",
                        column: x => x.ProId,
                        principalTable: "TBProdutos",
                        principalColumn: "ProId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBOrcamentoProdutos_ProId",
                table: "TBOrcamentoProdutos",
                column: "ProId");

            migrationBuilder.CreateIndex(
                name: "IX_TBOrcamentos_PesId",
                table: "TBOrcamentos",
                column: "PesId");

            migrationBuilder.CreateIndex(
                name: "IX_TBProdutos_CatId",
                table: "TBProdutos",
                column: "CatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBOrcamentoProdutos");

            migrationBuilder.DropTable(
                name: "TBOrcamentos");

            migrationBuilder.DropTable(
                name: "TBProdutos");

            migrationBuilder.DropTable(
                name: "TBPessoas");

            migrationBuilder.DropTable(
                name: "TBCategorias");
        }
    }
}
