using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleFacil.Api.Migrations
{
    /// <inheritdoc />
    public partial class CriarEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tournament",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    ChessResults = table.Column<string>(type: "VARCHAR", maxLength: 400, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tournament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "VARCHAR", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Nickname = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    Avatar = table.Column<string>(type: "VARCHAR", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    Role = table.Column<string>(type: "VARCHAR", nullable: false),
                    Blitz = table.Column<int>(type: "integer", nullable: false, defaultValue: 1900),
                    Rapid = table.Column<int>(type: "integer", nullable: false, defaultValue: 1900),
                    Classic = table.Column<int>(type: "integer", nullable: false, defaultValue: 1900),
                    Title = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    ShortTitle = table.Column<string>(type: "VARCHAR", maxLength: 5, nullable: false),
                    City = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    Birth = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CbxId = table.Column<int>(type: "integer", nullable: false),
                    FideId = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "playerNorms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Norm = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playerNorms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_playerNorms_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_playerNorms_user_UserId1",
                        column: x => x.UserId1,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "playerPodiums",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Place = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TournamentId = table.Column<long>(type: "bigint", nullable: false),
                    TournamentId1 = table.Column<long>(type: "bigint", nullable: true),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playerPodiums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_playerPodiums_tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_playerPodiums_tournament_TournamentId1",
                        column: x => x.TournamentId1,
                        principalTable: "tournament",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_playerPodiums_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_playerPodiums_user_UserId1",
                        column: x => x.UserId1,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "playerTournaments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RatingType = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    OldRating = table.Column<int>(type: "integer", nullable: false),
                    Variation = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TournamentId = table.Column<long>(type: "bigint", nullable: false),
                    TournamentId1 = table.Column<long>(type: "bigint", nullable: true),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playerTournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_playerTournaments_tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_playerTournaments_tournament_TournamentId1",
                        column: x => x.TournamentId1,
                        principalTable: "tournament",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_playerTournaments_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_playerTournaments_user_UserId1",
                        column: x => x.UserId1,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_playerNorms_UserId",
                table: "playerNorms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_playerNorms_UserId1",
                table: "playerNorms",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_playerPodiums_TournamentId",
                table: "playerPodiums",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_playerPodiums_TournamentId1",
                table: "playerPodiums",
                column: "TournamentId1");

            migrationBuilder.CreateIndex(
                name: "IX_playerPodiums_UserId",
                table: "playerPodiums",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_playerPodiums_UserId1",
                table: "playerPodiums",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_playerTournaments_TournamentId",
                table: "playerTournaments",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_playerTournaments_TournamentId1",
                table: "playerTournaments",
                column: "TournamentId1");

            migrationBuilder.CreateIndex(
                name: "IX_playerTournaments_UserId",
                table: "playerTournaments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_playerTournaments_UserId1",
                table: "playerTournaments",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playerNorms");

            migrationBuilder.DropTable(
                name: "playerPodiums");

            migrationBuilder.DropTable(
                name: "playerTournaments");

            migrationBuilder.DropTable(
                name: "tournament");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
