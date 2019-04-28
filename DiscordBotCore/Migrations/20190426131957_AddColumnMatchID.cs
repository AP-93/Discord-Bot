using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscordBotCore.Migrations
{
    public partial class AddColumnMatchID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "lastMatchId",
                table: "Players",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastMatchId",
                table: "Players");
        }
    }
}
