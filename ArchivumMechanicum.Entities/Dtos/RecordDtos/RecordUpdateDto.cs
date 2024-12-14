using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Entities.Dtos.RecordDtos
{
    public class RecordUpdateDto
    {
        public required string Title { get; set; } = "";

        public required string Inscription { get; set; } = "";

        public required string Scribe { get; set; } = "";

        public string Condition { get; set; } = "";

        public string Classification { get; set; } = "";

        public string ArchivingDate { get; set; } = "";
    }
}
