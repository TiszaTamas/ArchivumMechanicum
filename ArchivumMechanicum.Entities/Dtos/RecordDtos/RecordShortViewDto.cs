using ArchivumMechanicum.Entities.Entity_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Entities.Dtos.RecordDtos
{
    public class RecordShortViewDto
    {
        public string Identification { get; set; } = "";

        public string Title { get; set; } = "";

        public string Scribe { get; set; } = "";
    }
}
