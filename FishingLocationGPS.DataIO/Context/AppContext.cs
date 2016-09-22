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

namespace FishingLocationGPS.DataIO.Context
{
    public class AppContext: DbContext
    {
        public DbSet<Models.DbModels.FishingLocation> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "FishingAppData.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);

            //optionsBuilder.UseSqlite("Data Source=" + Path.Combine(ApplicationData.Current.LocalFolder.Path, ""));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        

    }
}
