using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskAllWebbedUp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DeskWidth = table.Column<int>(nullable: false),
                    DeskDepth = table.Column<int>(nullable: false),
                    NumberOfDrawers = table.Column<int>(nullable: false),
                    SurfaceMaterial = table.Column<int>(nullable: false),
                    RushDays = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    QuotePrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quote");
        }
    }
}
