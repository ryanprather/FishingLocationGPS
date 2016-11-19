using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingLocationGPS.Models
{
    public class PersonalGPSLocationNote
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonalGPSLocationNoteID { get; set; }

        [ForeignKey("PersonalGPSLocationID")]
        public int PersonalGPSLocationID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime FishingDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
