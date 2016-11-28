using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FishingLocationGPS.Client;

namespace FishingLocationGPS.Migrations
{
    [DbContext(typeof(DbAppContext))]
    [Migration("20161121212319_MigrationNewDB")]
    partial class MigrationNewDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("FishingLocationGPS.Models.MonitoredNOAALocation", b =>
                {
                    b.Property<int>("MonitoredNOAALocationID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("StationID");

                    b.Property<string>("Type");

                    b.HasKey("MonitoredNOAALocationID");

                    b.ToTable("MonitoredNOAALocations");
                });

            modelBuilder.Entity("FishingLocationGPS.Models.PersonalGPSLocation", b =>
                {
                    b.Property<int>("PersonalGPSLocationID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<int>("WaterDepth");

                    b.HasKey("PersonalGPSLocationID");

                    b.ToTable("PersonalGPSLocations");
                });
        }
    }
}
