using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace FishingLocationGPS.Models.DbModels
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public Guid LocationGuid { get; set; }

        
        //public Geopoint GpsLocation { get; set; }

        public String Name { get; set; }

        public String Notes { get; set; }
    }
}
