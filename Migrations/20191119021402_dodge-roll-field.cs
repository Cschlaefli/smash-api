using Microsoft.EntityFrameworkCore.Migrations;

namespace SmashApi.Migrations
{
    public partial class dodgerollfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DurationMaxPenalty",
                table: "Versions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Intangible",
                table: "Versions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntangibleMaxPenalty",
                table: "Versions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationMaxPenalty",
                table: "Versions");

            migrationBuilder.DropColumn(
                name: "Intangible",
                table: "Versions");

            migrationBuilder.DropColumn(
                name: "IntangibleMaxPenalty",
                table: "Versions");
        }
    }
}
