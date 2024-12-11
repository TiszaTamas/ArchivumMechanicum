using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Entities.Dtos.RelicDtos
{
    public class RelicCreateDto
    {
        public required string LocationIdentification { get; set; } = "";

        public required string Designation { get; set; } = "";

        public required string Description { get; set; } = "";
    }
}
