using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechNation.Desafio.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InicialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusNotaFiscal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusNotaFiscal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePagador = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroIdentificacao = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCobranca = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DocumentoNotaFiscal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentoBoletoBancario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdStatusNotaFiscal = table.Column<int>(type: "int", nullable: false),
                    StatusNotaFiscalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaFiscal_StatusNotaFiscal_IdStatusNotaFiscal",
                        column: x => x.IdStatusNotaFiscal,
                        principalTable: "StatusNotaFiscal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotaFiscal_StatusNotaFiscal_StatusNotaFiscalId",
                        column: x => x.StatusNotaFiscalId,
                        principalTable: "StatusNotaFiscal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_IdStatusNotaFiscal",
                table: "NotaFiscal",
                column: "IdStatusNotaFiscal");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_StatusNotaFiscalId",
                table: "NotaFiscal",
                column: "StatusNotaFiscalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotaFiscal");

            migrationBuilder.DropTable(
                name: "StatusNotaFiscal");
        }
    }
}
