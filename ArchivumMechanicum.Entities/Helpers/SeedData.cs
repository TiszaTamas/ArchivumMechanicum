using ArchivumMechanicum.Entities.Dtos.RecordDtos;
using ArchivumMechanicum.Entities.Dtos.RelicDtos;
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
        public List<RelicSeedDto> Relics { get; set; }
        public List<RecordSeedDto> Records { get; set; }
    }

}
