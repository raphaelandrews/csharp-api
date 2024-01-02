using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleFacil.Api.Migrations
{
    /// <inheritdoc />
    public partial class CriarEntidadeAreceber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "areceber",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ValorRecebido = table.Column<double>(type: "double precision", nullable: false),
                    DataRecebimento = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdNaturezaDeLancamento = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR", nullable: false),
                    ValorOriginal = table.Column<double>(type: "double precision", nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DataReferencia = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DataInativacao = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_areceber_naturezadelancamento_IdNaturezaDeLancamento",
                        column: x => x.IdNaturezaDeLancamento,
                        principalTable: "naturezadelancamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_areceber_user_IdUser",
                        column: x => x.IdUser,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_areceber_IdNaturezaDeLancamento",
                table: "areceber",
                column: "IdNaturezaDeLancamento");

            migrationBuilder.CreateIndex(
                name: "IX_areceber_IdUser",
                table: "areceber",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "areceber");
        }
    }
}
