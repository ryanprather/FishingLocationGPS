using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingLocationGPS.DataIO
{
    public class DataIO
    {
            
        public Models.DBModels.Location ConvertViewModel(Models.ViewModels.Location viewModel)
        {
            var location = new Models.DBModels.Location()
            {
                LocationGuid = viewModel.LocationGuid,
                Name = viewModel.Name,
                Notes = viewModel.Notes
            };

            try
            {
                var formatLocation = String.Format("POINT({0} {1})", viewModel.Latitude.ToString().Replace(",", "."), viewModel.Longitude.ToString().Replace(",", "."));
                location.GPSLocation = DbGeography.FromText(formatLocation);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid gps Coordantes");
            }

            return location;
        }
    }
}
