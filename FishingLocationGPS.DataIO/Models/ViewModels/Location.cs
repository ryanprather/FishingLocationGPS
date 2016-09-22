using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FishingLocationGPS.DataIO.Models.ViewModels
{
    public class Location
    {
        [Required]
        public Guid LocationGuid { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Name { get; set; }
        public string Notes { get; set; }
    }
}