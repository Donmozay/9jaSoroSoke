using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _9jasorosoke.Repositories.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarOwners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProofOfVehicleOwnerShip = table.Column<string>(nullable: false),
                    PurchaseReciept = table.Column<string>(nullable: false),
                    DateReported = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelingStationOwners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    NameOfDepot = table.Column<string>(nullable: false),
                    DatePurchased = table.Column<string>(nullable: false),
                    PurchaseReciept = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelingStationOwners", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarOwners");

            migrationBuilder.DropTable(
                name: "FuelingStationOwners");
        }
    }
}
