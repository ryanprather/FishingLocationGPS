using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingLocationGPS.Models
{
    public class NOAALocation
    {
        public String LocationId { get; set; }
        public Decimal Latitude { get; set; }
        public Decimal Longitude { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
    }
}
