using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Entities.Dtos.RelicDtos
{
    public class RelicShortViewDto
    {
        public string Identification { get; set; } = "";

        public string Designation { get; set; } = "";

        public string Classification { get; set; } = "";

        public int NumberOfRecords { get; set; }

    }
}
