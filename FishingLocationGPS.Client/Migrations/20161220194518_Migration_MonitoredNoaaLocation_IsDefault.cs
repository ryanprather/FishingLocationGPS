using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FishingLocationGPS.Migrations
{
    public partial class Migration_MonitoredNoaaLocation_IsDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "MonitoredNOAALocations",
                nullable: false,
                defaultValue: false);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "FishingDate",
            //    table: "PersonalGPSLocations",
            //    nullable: false);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedDate",
            //    table: "PersonalGPSLocations",
            //    nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_PersonalGPSLocationNotes",
            //    table: "PersonalGPSLocationNotes");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "MonitoredNOAALocations");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "FishingDate",
            //    table: "PersonalGPSLocationNotes",
            //    nullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedDate",
            //    table: "PersonalGPSLocationNotes",
            //    nullable: true);
            
        }
    }
}
