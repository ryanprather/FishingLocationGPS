using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace FishingLocationGPS.DataIO
{
    public class DataIO
    {
            
        public Models.DbModels.Location ConvertViewModel(Models.ViewModels.Location viewModel)
        {
            var location = new Models.DbModels.Location()
            {
                LocationGuid = viewModel.LocationGuid,
                Name = viewModel.Name,
                Notes = viewModel.Notes
            };

            try
            {
                BasicGeoposition position = new BasicGeoposition();
                position.Latitude = Double.Parse(viewModel.Latitude);
                position.Longitude = Double.Parse(viewModel.Longitude);
                Geopoint gpsPoint = new Geopoint(position);
                //location.GpsLocation = gpsPoint;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid gps Coordantes");
            }

            return location;
        }
    }
}
