using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingLocationGPS.Models
{
    public class PersonalGPSLocation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonalGPSLocationID { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public String Name { get; set; }

        public int WaterDepth { get; set; }

        public String Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public IEnumerable<Models.PersonalGPSLocationNote> PersonalGPSLocationNotes { get; set; }
    }
}
