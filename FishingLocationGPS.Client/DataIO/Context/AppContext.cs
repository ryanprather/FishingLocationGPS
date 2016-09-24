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
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "FishingAppData.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            
            optionsBuilder.UseSqlite(connection);
          }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.DbModels.FishingLocation>()
                            .HasKey(item => item.LocationId)
                            .HasName("LocationId");
            
          }
    }


}
