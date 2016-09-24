using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace FishingLocationGPS.Client.Models.DbModels
{
    [Table("FishingLocation")]
    public class FishingLocation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }
        
        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
        
        public String Name { get; set; }

        public String Notes { get; set; }
    }
}
