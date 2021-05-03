using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainC1810L.Migrations
{
    public partial class BookingTicketStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "bookingTickets",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "bookingTickets");
        }
    }
}
