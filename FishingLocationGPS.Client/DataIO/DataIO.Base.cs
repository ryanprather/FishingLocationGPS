using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using FishingLocationGPS.Models;

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
    }
}
