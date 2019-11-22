using Microsoft.EntityFrameworkCore.Migrations;

namespace SmashApi.Migrations
{
    public partial class addtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Moves",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Moves");
        }
    }
}
