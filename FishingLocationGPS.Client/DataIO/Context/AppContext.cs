using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace FishingLocationGPS.Client
{
    public class DbAppContext: DbContext
    {
        public DbSet<Models.PersonalGPSLocation> PersonalGPSLocations { get; set; }
        public DbSet<Models.MonitoredNOAALocation> MonitoredNOAALocations { get; set; }
        public DbSet<Models.PersonalGPSLocationNote> PersonalGPSLocationNotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=PersonalGPSDatabase.db");
            //optionsBuilder.UseSqlite("DataSource="+ Path.Combine(ApplicationData.Current.LocalFolder.Path, "PersonalGPSAppDatabase.db"));
        }
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Models.PersonalGPSLocation>()
        //                    .HasKey(item => item.PersonalGPSLocationID)
        //                    .HasName("PersonalGPSLocationID");

        //    modelBuilder.Entity<Models.MonitoredNOAALocation>()
        //                    .HasKey(item => item.MonitoredNOAALocationID)
        //                    .HasName("MonitoredNOAALocationID");
        //}
        
    }


}
