using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FishingLocationGPS.DataIO.Contexts
{
    public class AppContext : DbContext
    {
        // Your context has been configured to use a 'FishingApp' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FishingApp.DataIO.Contexts.FishingApp' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FishingApp' 
        // connection string in the application configuration file.
        public AppContext(): base("name=AppContext")
        {

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Models.DBModels.Location> Locations { get; set; }


    }
}
