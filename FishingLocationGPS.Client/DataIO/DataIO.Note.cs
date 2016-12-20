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

        public async Task<bool> DeleteNote(Models.PersonalGPSLocationNote note)
        {
            var isDeleted = false;

            var isValid = await PageHelper.ValidateObject(note);
            using (var dbContext = new DbAppContext())
            {
                var deleteItem = dbContext.PersonalGPSLocationNotes.First(item => item.PersonalGPSLocationNoteID == note.PersonalGPSLocationNoteID);
                if (deleteItem != null)
                {
                    dbContext.PersonalGPSLocationNotes.Remove(deleteItem);
                    dbContext.SaveChanges();
                }
            }

            return isDeleted;
        }
    }
}
