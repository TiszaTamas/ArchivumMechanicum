using ArchivumMechanicum.Entities.Entity_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Entities.Dtos.RelicDtos
{
    public class RelicViewDto
    {

        public string Identification { get; set; } = "";

        public string Designation { get; set; } = "";

        public string Classification { get; set; } = "";

        public string Description { get; set; } = "";

        public string FoundLocationName { get; set; } = "";

        public string Status { get; set; } = "";

        public IEnumerable<Record>? Records { get; set; }
    }
}
