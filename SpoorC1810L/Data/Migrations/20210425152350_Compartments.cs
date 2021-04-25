using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainC1810L.Migrations
{
    public partial class Compartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chair_Compartment_CompartmentId",
                table: "Chair");

            migrationBuilder.DropForeignKey(
                name: "FK_Compartment_trains_TrainId",
                table: "Compartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compartment",
                table: "Compartment");

            migrationBuilder.RenameTable(
                name: "Compartment",
                newName: "compartments");

            migrationBuilder.RenameIndex(
                name: "IX_Compartment_TrainId",
                table: "compartments",
                newName: "IX_compartments_TrainId");

            migrationBuilder.AddColumn<int>(
                name: "Numcloums",
                table: "compartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Numrows",
                table: "compartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "compartments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_compartments",
                table: "compartments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chair_compartments_CompartmentId",
                table: "Chair",
                column: "CompartmentId",
                principalTable: "compartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_compartments_trains_TrainId",
                table: "compartments",
                column: "TrainId",
                principalTable: "trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chair_compartments_CompartmentId",
                table: "Chair");

            migrationBuilder.DropForeignKey(
                name: "FK_compartments_trains_TrainId",
                table: "compartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_compartments",
                table: "compartments");

            migrationBuilder.DropColumn(
                name: "Numcloums",
                table: "compartments");

            migrationBuilder.DropColumn(
                name: "Numrows",
                table: "compartments");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "compartments");

            migrationBuilder.RenameTable(
                name: "compartments",
                newName: "Compartment");

            migrationBuilder.RenameIndex(
                name: "IX_compartments_TrainId",
                table: "Compartment",
                newName: "IX_Compartment_TrainId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compartment",
                table: "Compartment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chair_Compartment_CompartmentId",
                table: "Chair",
                column: "CompartmentId",
                principalTable: "Compartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compartment_trains_TrainId",
                table: "Compartment",
                column: "TrainId",
                principalTable: "trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
