using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FabricaGestao.Api.Migrations
{
    /// <inheritdoc />
    public partial class Alteracao_nomes_tabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBOrcamentoProdutos_TBOrcamentos_OrcId",
                table: "TBOrcamentoProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_TBOrcamentoProdutos_TBProdutos_ProId",
                table: "TBOrcamentoProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_TBOrcamentos_TBPessoas_PesId",
                table: "TBOrcamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_TBProdutos_TBCategorias_CatId",
                table: "TBProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_TBUsuarios_TBPerfis_PerId",
                table: "TBUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBUsuarios",
                table: "TBUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBProdutos",
                table: "TBProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBPessoas",
                table: "TBPessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBPerfis",
                table: "TBPerfis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBOrcamentos",
                table: "TBOrcamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBOrcamentoProdutos",
                table: "TBOrcamentoProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBCategorias",
                table: "TBCategorias");

            migrationBuilder.RenameTable(
                name: "TBUsuarios",
                newName: "TbUsuarios");

            migrationBuilder.RenameTable(
                name: "TBProdutos",
                newName: "TbProdutos");

            migrationBuilder.RenameTable(
                name: "TBPessoas",
                newName: "TbPessoas");

            migrationBuilder.RenameTable(
                name: "TBPerfis",
                newName: "TbPerfis");

            migrationBuilder.RenameTable(
                name: "TBOrcamentos",
                newName: "TbOrcamentos");

            migrationBuilder.RenameTable(
                name: "TBOrcamentoProdutos",
                newName: "TbOrcamentoProdutos");

            migrationBuilder.RenameTable(
                name: "TBCategorias",
                newName: "TbCategorias");

            migrationBuilder.RenameIndex(
                name: "IX_TBUsuarios_PerId",
                table: "TbUsuarios",
                newName: "IX_TbUsuarios_PerId");

            migrationBuilder.RenameIndex(
                name: "IX_TBProdutos_CatId",
                table: "TbProdutos",
                newName: "IX_TbProdutos_CatId");

            migrationBuilder.RenameIndex(
                name: "IX_TBOrcamentos_PesId",
                table: "TbOrcamentos",
                newName: "IX_TbOrcamentos_PesId");

            migrationBuilder.RenameIndex(
                name: "IX_TBOrcamentoProdutos_ProId",
                table: "TbOrcamentoProdutos",
                newName: "IX_TbOrcamentoProdutos_ProId");

            migrationBuilder.AlterColumn<int>(
                name: "PerAltPor",
                table: "TbPerfis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PerAltEm",
                table: "TbPerfis",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbUsuarios",
                table: "TbUsuarios",
                column: "UsuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbProdutos",
                table: "TbProdutos",
                column: "ProId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbPessoas",
                table: "TbPessoas",
                column: "PesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbPerfis",
                table: "TbPerfis",
                column: "PerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbOrcamentos",
                table: "TbOrcamentos",
                column: "OrcId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbOrcamentoProdutos",
                table: "TbOrcamentoProdutos",
                columns: new[] { "OrcId", "ProId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbCategorias",
                table: "TbCategorias",
                column: "CatId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbOrcamentoProdutos_TbOrcamentos_OrcId",
                table: "TbOrcamentoProdutos",
                column: "OrcId",
                principalTable: "TbOrcamentos",
                principalColumn: "OrcId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbOrcamentoProdutos_TbProdutos_ProId",
                table: "TbOrcamentoProdutos",
                column: "ProId",
                principalTable: "TbProdutos",
                principalColumn: "ProId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbOrcamentos_TbPessoas_PesId",
                table: "TbOrcamentos",
                column: "PesId",
                principalTable: "TbPessoas",
                principalColumn: "PesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbProdutos_TbCategorias_CatId",
                table: "TbProdutos",
                column: "CatId",
                principalTable: "TbCategorias",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbUsuarios_TbPerfis_PerId",
                table: "TbUsuarios",
                column: "PerId",
                principalTable: "TbPerfis",
                principalColumn: "PerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbOrcamentoProdutos_TbOrcamentos_OrcId",
                table: "TbOrcamentoProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_TbOrcamentoProdutos_TbProdutos_ProId",
                table: "TbOrcamentoProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_TbOrcamentos_TbPessoas_PesId",
                table: "TbOrcamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_TbProdutos_TbCategorias_CatId",
                table: "TbProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_TbUsuarios_TbPerfis_PerId",
                table: "TbUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbUsuarios",
                table: "TbUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbProdutos",
                table: "TbProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbPessoas",
                table: "TbPessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbPerfis",
                table: "TbPerfis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbOrcamentos",
                table: "TbOrcamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbOrcamentoProdutos",
                table: "TbOrcamentoProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbCategorias",
                table: "TbCategorias");

            migrationBuilder.RenameTable(
                name: "TbUsuarios",
                newName: "TBUsuarios");

            migrationBuilder.RenameTable(
                name: "TbProdutos",
                newName: "TBProdutos");

            migrationBuilder.RenameTable(
                name: "TbPessoas",
                newName: "TBPessoas");

            migrationBuilder.RenameTable(
                name: "TbPerfis",
                newName: "TBPerfis");

            migrationBuilder.RenameTable(
                name: "TbOrcamentos",
                newName: "TBOrcamentos");

            migrationBuilder.RenameTable(
                name: "TbOrcamentoProdutos",
                newName: "TBOrcamentoProdutos");

            migrationBuilder.RenameTable(
                name: "TbCategorias",
                newName: "TBCategorias");

            migrationBuilder.RenameIndex(
                name: "IX_TbUsuarios_PerId",
                table: "TBUsuarios",
                newName: "IX_TBUsuarios_PerId");

            migrationBuilder.RenameIndex(
                name: "IX_TbProdutos_CatId",
                table: "TBProdutos",
                newName: "IX_TBProdutos_CatId");

            migrationBuilder.RenameIndex(
                name: "IX_TbOrcamentos_PesId",
                table: "TBOrcamentos",
                newName: "IX_TBOrcamentos_PesId");

            migrationBuilder.RenameIndex(
                name: "IX_TbOrcamentoProdutos_ProId",
                table: "TBOrcamentoProdutos",
                newName: "IX_TBOrcamentoProdutos_ProId");

            migrationBuilder.AlterColumn<int>(
                name: "PerAltPor",
                table: "TBPerfis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PerAltEm",
                table: "TBPerfis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBUsuarios",
                table: "TBUsuarios",
                column: "UsuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBProdutos",
                table: "TBProdutos",
                column: "ProId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBPessoas",
                table: "TBPessoas",
                column: "PesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBPerfis",
                table: "TBPerfis",
                column: "PerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBOrcamentos",
                table: "TBOrcamentos",
                column: "OrcId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBOrcamentoProdutos",
                table: "TBOrcamentoProdutos",
                columns: new[] { "OrcId", "ProId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBCategorias",
                table: "TBCategorias",
                column: "CatId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBOrcamentoProdutos_TBOrcamentos_OrcId",
                table: "TBOrcamentoProdutos",
                column: "OrcId",
                principalTable: "TBOrcamentos",
                principalColumn: "OrcId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBOrcamentoProdutos_TBProdutos_ProId",
                table: "TBOrcamentoProdutos",
                column: "ProId",
                principalTable: "TBProdutos",
                principalColumn: "ProId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBOrcamentos_TBPessoas_PesId",
                table: "TBOrcamentos",
                column: "PesId",
                principalTable: "TBPessoas",
                principalColumn: "PesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBProdutos_TBCategorias_CatId",
                table: "TBProdutos",
                column: "CatId",
                principalTable: "TBCategorias",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBUsuarios_TBPerfis_PerId",
                table: "TBUsuarios",
                column: "PerId",
                principalTable: "TBPerfis",
                principalColumn: "PerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
