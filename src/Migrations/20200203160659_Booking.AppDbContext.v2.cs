using Microsoft.EntityFrameworkCore.Migrations;

namespace booking.Migrations
{
    public partial class BookingAppDbContextv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "show",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisplayLength",
                table: "salon",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayLength",
                table: "salon");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "show",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
