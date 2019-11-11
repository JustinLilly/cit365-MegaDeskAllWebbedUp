using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskAllWebbedUp.Migrations
{
    public partial class asdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuotePrice",
                table: "Quote");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuotePrice",
                table: "Quote",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
