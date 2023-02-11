using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWYDDB23.Server.Migrations
{
    public partial class devTestadmin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayEntries_Days_DayId",
                table: "DayEntries");

            migrationBuilder.AddForeignKey(
                name: "FK_DayEntries_Days_DayId",
                table: "DayEntries",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayEntries_Days_DayId",
                table: "DayEntries");

            migrationBuilder.AddForeignKey(
                name: "FK_DayEntries_Days_DayId",
                table: "DayEntries",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
