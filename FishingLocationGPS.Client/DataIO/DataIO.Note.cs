using FishingLocationGPS.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingLocationGPS.Client
{
    public partial class DataIO
    {
        public async Task<bool> AddNote(Models.PersonalGPSLocationNote note)
        {
            var isAdded = false;
            var isValid = await PageHelper.ValidateObject(note);
            if (isValid)
            {
                note.CreatedDate = DateTime.Now;
                using (var dbContext = new DbAppContext())
                {
                    dbContext.PersonalGPSLocationNotes.Add(note);
                    dbContext.SaveChanges();
                    isAdded = true;
                }
            }

            return isAdded;
        }

    }
}
