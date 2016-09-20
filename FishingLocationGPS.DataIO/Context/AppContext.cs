using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace FishingLocationGPS.DataIO.Context
{
    public class AppContext: DbContext
    {
        public DbSet<Models.DbModels.Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=fishingApp.db");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.DbModels.Location>()
                .HasKey(item => item.LocationGuid)
                .HasName("LocationGuid");
        }

        

    }
}
