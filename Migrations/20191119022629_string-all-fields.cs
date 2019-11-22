using Microsoft.EntityFrameworkCore.Migrations;

namespace SmashApi.Migrations
{
    public partial class stringallfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BaseDamage",
                table: "Versions",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "BaseDamage",
                table: "Versions",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
