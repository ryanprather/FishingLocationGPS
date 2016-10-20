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
        public DbSet<Models.DbModels.PersonalGPSLocation> PersonalGPSLocations { get; set; }
        public DbSet<Models.DbModels.MonitoredNOAALocation> MonitoredNOAALocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource="+ Path.Combine(ApplicationData.Current.LocalFolder.Path, "PersonalGPSAppDatabase.db"));
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.DbModels.PersonalGPSLocation>()
                            .HasKey(item => item.PersonalGPSLocationID)
                            .HasName("PersonalGPSLocationID");

            modelBuilder.Entity<Models.DbModels.MonitoredNOAALocation>()
                            .HasKey(item => item.MonitoredNOAALocationID)
                            .HasName("MonitoredNOAALocationID");
        }
        
    }


}
