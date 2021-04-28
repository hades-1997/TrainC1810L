using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainC1810L.Migrations
{
    public partial class passenger1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfTravel",
                table: "passengers");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<int>(nullable: false),
                    Field = table.Column<string>(nullable: true),
                    TrainNo = table.Column<int>(nullable: false),
                    TrainName = table.Column<string>(nullable: true),
                    RouteFromTo = table.Column<string>(nullable: true),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    Toa = table.Column<string>(nullable: true),
                    Numcloums = table.Column<int>(nullable: false),
                    Numrows = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    IdChair = table.Column<int>(nullable: false),
                    IdCompart = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfTravel",
                table: "passengers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
