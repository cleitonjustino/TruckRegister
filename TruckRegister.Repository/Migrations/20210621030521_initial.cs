using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TruckRegister.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelDescription = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    YearOfModel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearOfManufacture = table.Column<int>(type: "int", nullable: false),
                    IdModel = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Truck_Model_IdModel",
                        column: x => x.IdModel,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Truck_IdModel",
                table: "Truck",
                column: "IdModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Truck");

            migrationBuilder.DropTable(
                name: "Model");
        }
    }
}
