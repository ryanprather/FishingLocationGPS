using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using FishingLocationGPS.Models;
using Microsoft.EntityFrameworkCore;

namespace FishingLocationGPS.Client
{
    public class DataIO
    {
            
        public Models.DbModels.FishingLocation ConvertViewModel(Models.ViewModels.Location viewModel)
        {
            var location = new Models.DbModels.FishingLocation()
            {
                Name = viewModel.Name,
                Notes = viewModel.Notes
            };

            try
            {
                BasicGeoposition position = new BasicGeoposition();
                position.Latitude = Double.Parse(viewModel.Latitude);
                position.Longitude = Double.Parse(viewModel.Longitude);
                Geopoint gpsPoint = new Geopoint(position);
                location.Latitude = (decimal)position.Latitude;
                location.Longitude = (decimal)position.Longitude;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid gps Coordantes");
            }

            return location;
        }

        public void MirgrateDB()
        {
            using (var db = new DbAppContext())
            {
                db.Database.Migrate();

                var entities = db.Model.GetEntityTypes();
                foreach (var entity in entities)
                {
                    // Get values to create tables //
                    var tableName = "";
                    var annotations = entity.GetAnnotations();
                    tableName = 
                        (annotations != null && annotations.Count() > 0 && annotations.Any(item => item.Name.ToUpper().Contains("TABLENAME"))) ?
                        annotations.First(item => item.Name.ToUpper().Contains("TABLENAME")).Value.ToString() :
                        entity.Name;

                    

                    var nameCount = db.Database.ExecuteSqlCommand(
                    "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='" + tableName + "'");

                    var properties = entity.GetProperties();
                    
                    foreach (var property in properties)
                    {
                        var test = property;
                    }

                    

                    // Create table if needed //


                }
                

                //db.Database.OpenConnection();
                //db.Database.G
            }
        }
    }
}
