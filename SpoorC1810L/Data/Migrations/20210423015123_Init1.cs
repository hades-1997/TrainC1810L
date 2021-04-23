using Microsoft.EntityFrameworkCore.Migrations;

namespace SpoorC1810L.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trains_stations_StationId",
                table: "trains");

            migrationBuilder.DropIndex(
                name: "IX_trains_StationId",
                table: "trains");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "trains");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "trains",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_trains_StationId",
                table: "trains",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_trains_stations_StationId",
                table: "trains",
                column: "StationId",
                principalTable: "stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
