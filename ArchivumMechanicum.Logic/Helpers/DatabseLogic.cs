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
    public class DatabseLogic
    {
        Repositorium<Location> locationRepo;
        Repositorium<Relic> relicRepo;
        Repositorium<Record> recordRepo;

        public DatabseLogic(Repositorium<Location> locationRepo, Repositorium<Relic> relicRepo, Repositorium<Record> recordRepo)
        {
            this.locationRepo = locationRepo;
            this.relicRepo = relicRepo;
            this.recordRepo = recordRepo;
        }

        public void ClearDatabase()
        {
            recordRepo.DeleteAll();
            relicRepo.DeleteAll();
            locationRepo.DeleteAll();
        }

        public async Task PopulateDatabaseAsync()
        {
            if (!locationRepo.GetAll().Any()&& !relicRepo.GetAll().Any() && !recordRepo.GetAll().Any())
            {
                var jsonData = System.IO.File.ReadAllText("seedData.json");
                var seedData = JsonConvert.DeserializeObject<SeedData>(jsonData);


                if (seedData != null)
                {
                    foreach (var location in seedData.Locations)
                    {
                        locationRepo.Create(location);
                    }

                    IQueryable<Location> locations = locationRepo.GetAll();
                    foreach (var relic in seedData.Relics)
                    {
                        if (locations.FirstOrDefault(l => l.Name == relic.Origin) !=null)
                        {
                            var loc = locations.First(l => l.Name == relic.Origin);
                            Relic rec= new Relic
                            {
                                Designation = relic.Designation,
                                Classification = relic.Classification,
                                Description = relic.Description,
                                LocationIdentification = loc.Identification,
                                Location = loc
                            };
                            relicRepo.Create(rec);
                        }
                        else
                        {
                            relicRepo.Create(new Relic
                            {
                                Designation = relic.Designation,
                                Classification = relic.Classification,
                                Description = relic.Description
                            });
                        }
                    }

                    IQueryable<Relic> relics = relicRepo.GetAll();
                    foreach (var record in seedData.Records)
                    {
                        if (relics.FirstOrDefault(r => r.Designation == record.RelicName) != null&& locations.FirstOrDefault(r => r.Name == record.LocationName) != null)
                        {
                            var rec = relics.FirstOrDefault(r => r.Designation == record.RelicName);
                            var loc = locations.FirstOrDefault(r => r.Name == record.LocationName);
                            Record recor = new Record
                            {
                                Title = record.Title,
                                Inscription = record.Inscription,
                                Scribe = record.Scribe,
                                ArchivingDate = record.ArchivingDate,
                                RelicIdentification = rec.Identification,
                                LocationIdentification = loc.Identification,
                                Relic = rec,
                                Location = loc
                            };
                            recordRepo.Create(recor);
                        }
                        else
                        {
                            recordRepo.Create(new Record
                            {
                                Title = record.Title,
                                Inscription = record.Inscription,
                                Scribe = record.Scribe,
                                ArchivingDate = record.ArchivingDate
                            });
                        }
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
