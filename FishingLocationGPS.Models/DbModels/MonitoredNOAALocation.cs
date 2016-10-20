using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingLocationGPS.Models.DbModels
{
    public class MonitoredNOAALocation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MonitoredNOAALocationID { get; set; }
        
        public decimal Latitude { get; set; }
        
        public decimal Longitude { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public int StationID { get; set; }

        public String Type { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
