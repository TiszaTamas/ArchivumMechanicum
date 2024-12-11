using ArchivumMechanicum.Data;
using ArchivumMechanicum.Entities.Entity_Models;
using ArchivumMechanicum.Entities.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Logic.Helpers
{
    public class DatabaseSeeder
    {
        Repositorium<Location> locationRepo;

        public DatabaseSeeder(Repositorium<Location> locationRepo)
        {
            this.locationRepo = locationRepo;
        }

        public async Task PopulateDatabaseAsync()
        {
            //!ctx.Locations.Any() && !ctx.Relics.Any() && !ctx.Records.Any()
            if (!locationRepo.GetAll().Any())
            {
                var jsonData = System.IO.File.ReadAllText("seedData.json");

                var seedData = JsonConvert.DeserializeObject<SeedData>(jsonData);

                if (seedData != null)
                {
                    foreach (var location in seedData.Locations)
                    {
                        locationRepo.Create(location);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Database is already populated.");
            }
        }
    }

}
