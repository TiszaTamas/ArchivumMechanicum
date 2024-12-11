using ArchivumMechanicum.Entities.Entity_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Entities.Helpers
{
    public class SeedData
    {
        public List<Location> Locations { get; set; }
        public List<Relic> Relics { get; set; }
        public List<Record> Records { get; set; }
    }

}
