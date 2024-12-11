using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Entities.Dtos.RecordDtos
{
    public class RecordViewDto
    {
        public string Identification { get; set; } = "";

        public string Title { get; set; } = "";

        public string Scribe { get; set; } = "";

        public string OriginLocationName { get; set; } = "";

        public string TiedRelicName { get; set; } = "";

        public string Inscription { get; set; } = "";

        public string Condition { get; set; } = "";

        public string Classification { get; set; } = "";

        public string ArchivingDate { get; set; } = "";
    }
}
