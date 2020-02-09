using Microsoft.EntityFrameworkCore.Migrations;

namespace booking.Migrations
{
    public partial class DisplayRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayLength",
                table: "salon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayLength",
                table: "salon",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
