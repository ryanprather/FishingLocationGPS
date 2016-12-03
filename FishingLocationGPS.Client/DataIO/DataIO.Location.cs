using FishingLocationGPS.Client;
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
        public async Task<bool> AddLocation(Models.PersonalGPSLocation location)
        {
            var isAdded = false;
            var isValid = await PageHelper.ValidateObject(location);
            if (isValid)
            {
                location = this.ValidateGPSCoordinates(location);
                location.CreatedDate = DateTime.Now;
                using (var dbContext = new DbAppContext())
                {
                    dbContext.PersonalGPSLocations.Add(location);
                    dbContext.SaveChanges();
                    isAdded = true;
                }
            }
            return isAdded;
        }

        public async Task<bool> EditLocation(Models.PersonalGPSLocation location)
        {
            var isEdited = false;
            var isValid = await PageHelper.ValidateObject(location);
            location = ValidateGPSCoordinates(location);
            if (isValid)
            {
                using (var dbContext = new DbAppContext())
                {
                    var editItem = dbContext.PersonalGPSLocations.First(item => item.PersonalGPSLocationID == location.PersonalGPSLocationID);
                    if (editItem != null)
                    {
                        editItem.Name = location.Name;
                        editItem.Latitude = location.Latitude;
                        editItem.Longitude = location.Longitude;
                        editItem.Description = location.Description;
                        editItem.WaterDepth = location.WaterDepth;
                        editItem.ModifiedDate = DateTime.Now;
                        dbContext.SaveChanges();
                        isEdited = true;
                    }
                }
            }

            return isEdited;
        }

        public async Task<bool> DeleteLocation(Models.PersonalGPSLocation location)
        {
            var isDeleted = false;

            var isValid = await PageHelper.ValidateObject(location);
            using (var dbContext = new DbAppContext())
            {
                var deleteItem = dbContext.PersonalGPSLocations.First(item => item.PersonalGPSLocationID == location.PersonalGPSLocationID);
                if (deleteItem != null)
                {
                    dbContext.PersonalGPSLocations.Remove(deleteItem);
                    dbContext.SaveChanges();
                }
                // need to delete notes associated with the location //

            }

            return isDeleted;
        }
    }
}
