using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Entities.Dtos.RelicDtos
{
    public class RelicUpdateDto
    {
        
        public required string Designation { get; set; } = "";

        public required string Description { get; set; } = "";

        public string Classification { get; set; } = "";

        public string Status { get; set; } = "";
    }
}
