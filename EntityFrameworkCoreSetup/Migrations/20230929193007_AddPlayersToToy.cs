using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCoreSetup.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayersToToy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Players_PlayerId",
                table: "Toys");

            migrationBuilder.DropIndex(
                name: "IX_Toys_PlayerId",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Toys");

            migrationBuilder.CreateTable(
                name: "PlayerToy",
                columns: table => new
                {
                    PlayersPlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ToysToyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerToy", x => new { x.PlayersPlayerId, x.ToysToyId });
                    table.ForeignKey(
                        name: "FK_PlayerToy_Players_PlayersPlayerId",
                        column: x => x.PlayersPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerToy_Toys_ToysToyId",
                        column: x => x.ToysToyId,
                        principalTable: "Toys",
                        principalColumn: "ToyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerToy_ToysToyId",
                table: "PlayerToy",
                column: "ToysToyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerToy");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Toys",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toys_PlayerId",
                table: "Toys",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Players_PlayerId",
                table: "Toys",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId");
        }
    }
}
