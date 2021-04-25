using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainC1810L.Migrations
{
    public partial class Chair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chair_compartments_CompartmentId",
                table: "Chair");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chair",
                table: "Chair");

            migrationBuilder.RenameTable(
                name: "Chair",
                newName: "chairs");

            migrationBuilder.RenameIndex(
                name: "IX_Chair_CompartmentId",
                table: "chairs",
                newName: "IX_chairs_CompartmentId");

            migrationBuilder.AddColumn<string>(
                name: "Sign",
                table: "chairs",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_chairs",
                table: "chairs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_chairs_compartments_CompartmentId",
                table: "chairs",
                column: "CompartmentId",
                principalTable: "compartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chairs_compartments_CompartmentId",
                table: "chairs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_chairs",
                table: "chairs");

            migrationBuilder.DropColumn(
                name: "Sign",
                table: "chairs");

            migrationBuilder.RenameTable(
                name: "chairs",
                newName: "Chair");

            migrationBuilder.RenameIndex(
                name: "IX_chairs_CompartmentId",
                table: "Chair",
                newName: "IX_Chair_CompartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chair",
                table: "Chair",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chair_compartments_CompartmentId",
                table: "Chair",
                column: "CompartmentId",
                principalTable: "compartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
