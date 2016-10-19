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
        public DbSet<Models.DbModels.FishingLocation> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource="+ Path.Combine(ApplicationData.Current.LocalFolder.Path, "FishingAppData.db"));
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.DbModels.FishingLocation>()
                            .HasKey(item => item.LocationId)
                            .HasName("LocationId");    
        }
        
    }


}
