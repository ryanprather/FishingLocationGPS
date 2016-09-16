using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace FishingLocationGPS.Models.DbModels
{
    public class Location
    {
        [Key]
        public Guid LocationGuid { get; set; }

        [Required]
        public Geopoint GPSLocation { get; set; }

        [Required]
        public string Name { get; set; }

        public string Notes { get; set; }
    }
}
