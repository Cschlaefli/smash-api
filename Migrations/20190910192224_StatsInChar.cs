using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmashApi.Migrations
{
    public partial class StatsInChar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stat");

            migrationBuilder.AddColumn<float>(
                name: "AirSpeed",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "FallSpeed",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "FastFall",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Gravity",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "InitialDash",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "JumpSquat",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "RunSpeed",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ShieldDrop",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShieldGrab",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "TotalAirAcceleration",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Characters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirSpeed",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "FallSpeed",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "FastFall",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Gravity",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "InitialDash",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "JumpSquat",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "RunSpeed",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ShieldDrop",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ShieldGrab",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "TotalAirAcceleration",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Characters");

            migrationBuilder.CreateTable(
                name: "Stat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AirSpeed = table.Column<float>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    FallSpeed = table.Column<float>(nullable: false),
                    FastFall = table.Column<float>(nullable: false),
                    Gravity = table.Column<float>(nullable: false),
                    InitialDash = table.Column<float>(nullable: false),
                    JumpSquat = table.Column<int>(nullable: false),
                    RunSpeed = table.Column<float>(nullable: false),
                    ShieldDrop = table.Column<int>(nullable: false),
                    ShieldGrab = table.Column<int>(nullable: false),
                    TotalAirAcceleration = table.Column<float>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stat_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stat_CharacterId",
                table: "Stat",
                column: "CharacterId",
                unique: true);
        }
    }
}
