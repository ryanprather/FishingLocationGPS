using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingLocationGPS.Models.DbModels
{
    public class Location
    {
        public Guid LocationGuid { get; set; }
        public byte[] GpsLocation { get; set; }
        public String Name { get; set; }
        public String Notes { get; set; }
    }
}
