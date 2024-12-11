using ArchivumMechanicum.Data;
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
        private readonly ArchivumContext ctx;

        public DatabaseSeeder(ArchivumContext context)
        {
            ctx = context;
        }

        public async Task PopulateDatabaseAsync()
        {
            if (!ctx.Locations.Any() && !ctx.Relics.Any() && !ctx.Records.Any())
            {
                var jsonData = System.IO.File.ReadAllText("seedData.json");

                var seedData = JsonConvert.DeserializeObject<SeedData>(jsonData);

                if (seedData != null)
                {
                    ctx.Locations.AddRange(seedData.Locations);
                    ctx.Relics.AddRange(seedData.Relics);
                    ctx.Records.AddRange(seedData.Records);
                    ctx.SaveChanges();
                }
            }
            else
            {
                throw new InvalidOperationException("Database is already populated.");
            }
        }
    }

}
