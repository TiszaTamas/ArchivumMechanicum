using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArchivumMechanicum.Entities.Entity_Models
{
    public class Relic
    {
        //        1. Table: Relics
        //Current Variables:

        //name(good, intuitive)
        //type(e.g., weapon, artifact, machine spirit—works well)
        //description/essence(could be essence or specification for an archaic feel)
        //records(relation to Records table; keep)
        //origin(relation to Places table; consider naming provenance or forge_origin for a thematic touch)
        //found(relation to Places table; rename discovery_site for clarity)
        //Suggestions:

        //Add status(e.g., "functional," "damaged," "lost")
        //Add classification(e.g., archeotech, xenotech, heretekal)

        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Identification { get; set; } //ID

        [StringLength(50)]
        public string Designation { get; set; } //name

        [StringLength(50)]
        public string Classification { get; set; } //type

        [StringLength(50)]
        public string Description { get; set; } //description

        [StringLength(50)]
        public string Status { get; set; } //State of the relic

        [NotMapped]
        public virtual ICollection<Record>? Records { get; set; }
    }
}
