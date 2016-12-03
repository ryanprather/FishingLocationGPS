using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using FishingLocationGPS.Models;
using Microsoft.EntityFrameworkCore;
using FishingLocationGPS.Client.Helpers;

namespace FishingLocationGPS.Client
{
    public partial class DataIO
    {
        
        public Models.PersonalGPSLocation ValidateGPSCoordinates(Models.PersonalGPSLocation location)
        {
            try
            {
                BasicGeoposition position = new BasicGeoposition();
                position.Latitude = Double.Parse(location.Latitude.ToString());
                position.Longitude = Double.Parse(location.Longitude.ToString());
                Geopoint gpsPoint = new Geopoint(position);
                location.Latitude = (decimal)position.Latitude;
                location.Longitude = (decimal)position.Longitude;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid gps coordantes");
            }

            return location;
        }

        public List<Models.PersonalGPSLocation> GetLocations()
        {
            var locations = null as List<Models.PersonalGPSLocation>;
            using (var dbContext = new DbAppContext())
            {
                locations = dbContext.PersonalGPSLocations
                    .Where(item => item.Name != String.Empty)
                    .OrderBy(item => item.PersonalGPSLocationID).ToList();
            }

            return locations;
        }

        public List<Models.PersonalGPSLocationNote> GetNotes()
        {
            var notes = null as List<Models.PersonalGPSLocationNote>;
            using (var dbContext = new DbAppContext())
            {
                notes = dbContext.PersonalGPSLocationNotes
                    .Where(item => item.Title != String.Empty)
                    .OrderBy(item => item.PersonalGPSLocationNoteID).ToList();
            }

            return notes;
        }

    }
}
