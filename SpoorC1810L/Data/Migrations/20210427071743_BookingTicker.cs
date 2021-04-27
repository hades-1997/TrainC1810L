using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainC1810L.Migrations
{
    public partial class BookingTicker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookingTickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(nullable: false),
                    PassengerId = table.Column<int>(nullable: false),
                    ChairId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookingTickets_chairs_ChairId",
                        column: x => x.ChairId,
                        principalTable: "chairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookingTickets_passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingTickets_ChairId",
                table: "bookingTickets",
                column: "ChairId");

            migrationBuilder.CreateIndex(
                name: "IX_bookingTickets_PassengerId",
                table: "bookingTickets",
                column: "PassengerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingTickets");
        }
    }
}
