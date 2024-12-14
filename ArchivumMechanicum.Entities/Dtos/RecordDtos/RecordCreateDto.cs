using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Entities.Dtos.RecordDtos
{
    public class RecordCreateDto
    {
        public required string RelicIdentification { get; set; } = "";

        public required string LocationIdentification { get; set; } = "";

        public required string Title { get; set; } = "";

        public required string Inscription { get; set; } = "";

        public required string Scribe { get; set; } = "";

        public required string ArchivingDate { get; set; } = "";
    }
}
