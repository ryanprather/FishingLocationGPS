using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net;
using System.Net.Http;
using FishingLocationGPS.Client.Helpers;

namespace FishingLocationGPS.Client
{
    public partial class DataIO
    {
        public async Task<IEnumerable<Models.NOAALocation>> GetNoaaActiveLocations()
        {
            var stations = new List<Models.NOAALocation>();
            try
            {
                var client = new HttpClient();
                var response = await client.GetStreamAsync(NOAAActiveStations);
                XDocument xmlDoc = XDocument.Load(response);
                foreach (var xmlStation in xmlDoc.Descendants("station"))
                {
                    if (xmlStation != null && xmlStation.Attribute("met") != null && xmlStation.Attribute("met").Value == "y")
                    {
                        var station = new Models.NOAALocation()
                        {
                            LocationId = (xmlStation.Attribute("id") != null && xmlStation.Attribute("id").Value != null) ? xmlStation.Attribute("id").Value :  "" ,
                            Latitude = (xmlStation.Attribute("lat") != null && xmlStation.Attribute("lat").Value != null) ? decimal.Parse(xmlStation.Attribute("lat").Value) : 0,
                            Longitude = (xmlStation.Attribute("lon") != null && xmlStation.Attribute("lon").Value != null) ? decimal.Parse(xmlStation.Attribute("lon").Value) : 0,
                            Name = (xmlStation.Attribute("name") != null && xmlStation.Attribute("name").Value != null && xmlStation.Attribute("name").Value != String.Empty) ? xmlStation.Attribute("name").Value : "N/A",
                            Type = (xmlStation.Attribute("type") != null && xmlStation.Attribute("type").Value != null && xmlStation.Attribute("type").Value != String.Empty) ? xmlStation.Attribute("type").Value : "N/A",
                        };
                        stations.Add(station);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return stations;
        }

        public async Task<bool> AddMonitoredNoaaStation(Models.MonitoredNOAALocation monitoredNoaaLocation)
        {
            var isAdded = false;
            monitoredNoaaLocation.CreatedDate = DateTime.Now;
            using (var dbContext = new DbAppContext())
            {
                if (monitoredNoaaLocation.IsDefault)
                {
                    dbContext.MonitoredNOAALocations.ToList().ForEach(item => item.IsDefault = false);
                }

                dbContext.MonitoredNOAALocations.Add(monitoredNoaaLocation);
                dbContext.SaveChanges();
                isAdded = true;
            }

            return isAdded;
        }

        public async void GetNoaa_Waves(Models.NOAALocation noaaLocation)
        {
            var formatted_NOAAWebService = DataIO.NOAA_WebService.Replace("@@ObservedProperty", "waves").Replace("@StationID", noaaLocation.LocationId);
            var client = new HttpClient();
            var response = await client.GetStreamAsync(formatted_NOAAWebService);


        }
    }
}
