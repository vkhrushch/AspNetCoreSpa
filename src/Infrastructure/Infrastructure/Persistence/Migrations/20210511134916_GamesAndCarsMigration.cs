using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreSpa.Infrastructure.Persistence.Migrations
{
    public partial class GamesAndCarsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameDeveloperLevels",
                columns: table => new
                {
                    GameDeveloperLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDeveloperLevels", x => x.GameDeveloperLevelId);
                });

            migrationBuilder.CreateTable(
                name: "GameDifficultyLevels",
                columns: table => new
                {
                    GameDifficultyLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDifficultyLevels", x => x.GameDifficultyLevelId);
                });

            migrationBuilder.CreateTable(
                name: "GameFeatureDevelopmentStates",
                columns: table => new
                {
                    GameFeatureDevelopmentStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameFeatureDevelopmentStates", x => x.GameFeatureDevelopmentStateId);
                });

            migrationBuilder.CreateTable(
                name: "GameGenres",
                columns: table => new
                {
                    GameGenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenres", x => x.GameGenreId);
                });

            migrationBuilder.CreateTable(
                name: "GameDevelopers",
                columns: table => new
                {
                    GameDeveloperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DeveloperLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDevelopers", x => x.GameDeveloperId);
                    table.ForeignKey(
                        name: "FK_GameDevelopers_GameDeveloperLevels",
                        column: x => x.DeveloperLevelId,
                        principalTable: "GameDeveloperLevels",
                        principalColumn: "GameDeveloperLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GameDifficultyLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_GameDifficultyLevels",
                        column: x => x.GameDifficultyLevelId,
                        principalTable: "GameDifficultyLevels",
                        principalColumn: "GameDifficultyLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameFeatures",
                columns: table => new
                {
                    GameFeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    DevelopmentStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameFeatures", x => x.GameFeatureId);
                    table.ForeignKey(
                        name: "FK_GameFeatures_DevelopmentStates",
                        column: x => x.DevelopmentStateId,
                        principalTable: "GameFeatureDevelopmentStates",
                        principalColumn: "GameFeatureDevelopmentStateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameFeatures_GameDevelopers",
                        column: x => x.DeveloperId,
                        principalTable: "GameDevelopers",
                        principalColumn: "GameDeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameFeatures_Games",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGenreGames",
                columns: table => new
                {
                    GameGenreId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenreGames", x => new { x.GameGenreId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GameGenreGames_GameGenres_GameGenreId",
                        column: x => x.GameGenreId,
                        principalTable: "GameGenres",
                        principalColumn: "GameGenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenreGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameDevelopers_DeveloperLevelId",
                table: "GameDevelopers",
                column: "DeveloperLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_GameFeatures_DeveloperId",
                table: "GameFeatures",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_GameFeatures_DevelopmentStateId",
                table: "GameFeatures",
                column: "DevelopmentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_GameFeatures_GameId",
                table: "GameFeatures",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenreGames_GameId",
                table: "GameGenreGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameDifficultyLevelId",
                table: "Games",
                column: "GameDifficultyLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameFeatures");

            migrationBuilder.DropTable(
                name: "GameGenreGames");

            migrationBuilder.DropTable(
                name: "GameFeatureDevelopmentStates");

            migrationBuilder.DropTable(
                name: "GameDevelopers");

            migrationBuilder.DropTable(
                name: "GameGenres");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GameDeveloperLevels");

            migrationBuilder.DropTable(
                name: "GameDifficultyLevels");
        }
    }
}
