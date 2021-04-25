using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainC1810L.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compartment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Toa = table.Column<string>(nullable: true),
                    TrainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compartment_trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "trains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chair",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chair", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chair_Compartment_CompartmentId",
                        column: x => x.CompartmentId,
                        principalTable: "Compartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chair_CompartmentId",
                table: "Chair",
                column: "CompartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Compartment_TrainId",
                table: "Compartment",
                column: "TrainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chair");

            migrationBuilder.DropTable(
                name: "Compartment");
        }
    }
}
