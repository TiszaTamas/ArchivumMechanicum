﻿using ArchivumMechanicum.Entities.Entity_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Entities.Dtos.LocationDtos
{
    public class LocationViewDto
    {
        public class LocationShortViewDto
        {
            public string Identification { get; set; } = "";

            public string Name { get; set; } = "";

            public string Custodian { get; set; } = "";

            public string Significance { get; set; } = "";

            public string Coordinates { get; set; } = "";

            public string Sector { get; set; } = "";

            public IEnumerable<Relic>? Relics { get; set; }

            public IEnumerable<Record>? Records { get; set; }
        }
    }
}