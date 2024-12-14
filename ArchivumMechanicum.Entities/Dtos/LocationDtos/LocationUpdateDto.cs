using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Entities.Dtos.LocationDtos
{
    public class LocationUpdateDto
    {
        public required string Name { get; set; } = "";

        public required string Sector { get; set; } = "";

        public required string Custodian { get; set; } = "";

        public string Significance { get; set; } = "";

        public string Coordinates { get; set; } = "";

    }
}
