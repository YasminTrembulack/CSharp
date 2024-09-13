using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    /// <inheritdoc />
    public partial class InitialModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    AttackSpeed = table.Column<int>(type: "int", nullable: false),
                    DefenseSpeed = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecondTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BaseStatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinStatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaxStatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntroducedInId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvolvesFrom = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemons_Generations_IntroducedInId",
                        column: x => x.IntroducedInId,
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemons_Pokemons_EvolvesFrom",
                        column: x => x.EvolvesFrom,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemons_Stats_BaseStatsId",
                        column: x => x.BaseStatsId,
                        principalTable: "Stats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemons_Stats_MaxStatsId",
                        column: x => x.MaxStatsId,
                        principalTable: "Stats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemons_Stats_MinStatsId",
                        column: x => x.MinStatsId,
                        principalTable: "Stats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemons_Types_MainTypeId",
                        column: x => x.MainTypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemons_Types_SecondTypeId",
                        column: x => x.SecondTypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeEffects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttackerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Multiplier = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeEffects_Types_AttackerId",
                        column: x => x.AttackerId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypeEffects_Types_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_BaseStatsId",
                table: "Pokemons",
                column: "BaseStatsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_EvolvesFrom",
                table: "Pokemons",
                column: "EvolvesFrom",
                unique: true,
                filter: "[EvolvesFrom] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_IntroducedInId",
                table: "Pokemons",
                column: "IntroducedInId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_MainTypeId",
                table: "Pokemons",
                column: "MainTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_MaxStatsId",
                table: "Pokemons",
                column: "MaxStatsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_MinStatsId",
                table: "Pokemons",
                column: "MinStatsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_SecondTypeId",
                table: "Pokemons",
                column: "SecondTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeEffects_AttackerId",
                table: "TypeEffects",
                column: "AttackerId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeEffects_ReceiverId",
                table: "TypeEffects",
                column: "ReceiverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "TypeEffects");

            migrationBuilder.DropTable(
                name: "Generations");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
