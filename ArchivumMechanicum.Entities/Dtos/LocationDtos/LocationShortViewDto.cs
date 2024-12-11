using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Entities.Dtos.LocationDtos
{
    public class LocationShortViewDto
    {
        public string Identification { get; set; } = "";

        public string Name { get; set; } = "";

        public string Custodian { get; set; } = "";

        public string Sector { get; set; } = "";

        public int NumberOfRelics { get; set; }

    }
}
