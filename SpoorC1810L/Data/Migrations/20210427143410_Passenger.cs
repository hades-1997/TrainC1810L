using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainC1810L.Migrations
{
    public partial class Passenger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Field",
                table: "passengers");

            migrationBuilder.DropColumn(
                name: "TrainNo",
                table: "passengers");

            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                table: "passengers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "passengers",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<string>(
                name: "Field",
                table: "passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainNo",
                table: "passengers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
