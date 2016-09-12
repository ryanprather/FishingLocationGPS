using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingLocationGPS.Models.DBModels
{
    public class Location
    {
        [Key]
        public Guid LocationGuid { get; set; }

        [Required]
        public DbGeography GPSLocation { get; set; }

        [Required]
        public string Name { get; set; }

        public string Notes { get; set; }
    }
}
