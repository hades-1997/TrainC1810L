using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainC1810L.Migrations
{
    public partial class Char1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fares");

            migrationBuilder.DropColumn(
                name: "Sign",
                table: "chairs");

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "chairs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seats",
                table: "chairs");

            migrationBuilder.AddColumn<string>(
                name: "Sign",
                table: "chairs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "fares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    TypeOfCompartment = table.Column<int>(type: "int", nullable: false),
                    TypeOfTrain = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fares", x => x.Id);
                });
        }
    }
}
