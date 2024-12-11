using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Entities.Dtos.LocationDtos
{
    public class LocationCreateDto
    {
        public required string Name { get; set; } = "";

        public required string Sector { get; set; } = "";

        public required string Custodian { get; set; } = "";
    }
}
