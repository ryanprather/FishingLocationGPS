using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingLocationGPS.DataIO.Context
{
    public class AppContext: DbContext
    {
        public DbSet<Models.DbModels.Location> locations { get; set; }

    }
}
