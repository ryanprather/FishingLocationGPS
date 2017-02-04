using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FishingLocationGPS.Client;

namespace FishingLocationGPS.Migrations
{
    [DbContext(typeof(DbAppContext))]
    partial class DbAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("FishingLocationGPS.Models.MonitoredNOAALocation", b =>
                {
                    b.Property<int>("MonitoredNOAALocationID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<bool>("IsDefault");

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("StationID")
                        .IsRequired();

                    b.Property<string>("Type");

                    b.HasKey("MonitoredNOAALocationID");

                    b.ToTable("MonitoredNOAALocations");
                });

            modelBuilder.Entity("FishingLocationGPS.Models.PersonalGPSLocation", b =>
                {
                    b.Property<int>("PersonalGPSLocationID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("WaterDepth");

                    b.HasKey("PersonalGPSLocationID");

                    b.ToTable("PersonalGPSLocations");
                });

            modelBuilder.Entity("FishingLocationGPS.Models.PersonalGPSLocationNote", b =>
                {
                    b.Property<int>("PersonalGPSLocationNoteID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime>("FishingDate");

                    b.Property<int>("PersonalGPSLocationID");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("PersonalGPSLocationNoteID");

                    b.ToTable("PersonalGPSLocationNotes");
                });
        }
    }
}
