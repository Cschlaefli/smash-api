using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmashApi.Migrations
{
    public partial class Stats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Gravity = table.Column<float>(nullable: false),
                    RunSpeed = table.Column<float>(nullable: false),
                    InitialDash = table.Column<float>(nullable: false),
                    AirSpeed = table.Column<float>(nullable: false),
                    TotalAirAcceleration = table.Column<float>(nullable: false),
                    FallSpeed = table.Column<float>(nullable: false),
                    FastFall = table.Column<float>(nullable: false),
                    ShieldGrab = table.Column<int>(nullable: false),
                    ShieldDrop = table.Column<int>(nullable: false),
                    JumpSquat = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stat");
        }
    }
}
