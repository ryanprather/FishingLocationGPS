using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FishingLocationGPS.Migrations
{
    public partial class INIT_Migration : Migration
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
                    StationID = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
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
                    Description = table.Column<string>(nullable: true),
                    WaterDepth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalGPSLocations", x => x.PersonalGPSLocationID);
                });

            migrationBuilder.CreateTable(
                name: "PersonalGPSLocationNotes",
                columns: table => new
                {
                    PersonalGPSLocationNoteID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    PersonalGPSLocationID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FishingDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoredNOAALocations", x => x.PersonalGPSLocationNoteID);
                    table.ForeignKey("FK_PersonalGPSLocationID", x => x.PersonalGPSLocationID, "PersonalGPSLocations", "PersonalGPSLocationID");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonitoredNOAALocations");

            migrationBuilder.DropTable(
                name: "PersonalGPSLocations");

            migrationBuilder.DropTable(
                name: "PersonalGPSLocationNotes");
        }
    }
}
