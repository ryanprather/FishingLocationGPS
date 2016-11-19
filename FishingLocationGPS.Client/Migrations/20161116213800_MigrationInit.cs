using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FishingLocationGPS.Migrations
{
    public partial class MigrationInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonitoredNOAALocations",
                columns: table => new
                {
                    MonitoredNOAALocationID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    StationID = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoredNOAALocations", x => x.MonitoredNOAALocationID);
                });

            migrationBuilder.CreateTable(
                name: "PersonalGPSLocations",
                columns: table => new
                {
                    PersonalGPSLocationID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    WaterDepth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalGPSLocations", x => x.PersonalGPSLocationID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonitoredNOAALocations");

            migrationBuilder.DropTable(
                name: "PersonalGPSLocations");
        }
    }
}
