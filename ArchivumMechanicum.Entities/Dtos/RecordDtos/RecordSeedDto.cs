using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Entities.Dtos.RecordDtos
{
    public class RecordSeedDto
    {
        public string Title { get; set; } = "";

        public string Inscription { get; set; } = "";

        public string Scribe { get; set; } = "";

        public string ArchivingDate { get; set; } = "";

        public string RelicName { get; set; } = "";

        public string LocationName { get; set; } = "";
    }
}
