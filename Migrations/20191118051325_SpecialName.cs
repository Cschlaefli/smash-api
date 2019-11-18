using Microsoft.EntityFrameworkCore.Migrations;

namespace SmashApi.Migrations
{
    public partial class SpecialName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecialName",
                table: "Moves",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialName",
                table: "Moves");
        }
    }
}
