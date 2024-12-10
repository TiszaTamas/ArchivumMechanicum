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
using ArchivumMechanicum.Entities.Helpers;

namespace ArchivumMechanicum.Entities.Entity_Models
{
    public class Relic : IdentityEntity
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

        /// <summary>
        /// Id for Relic using Guid.
        /// </summary>
        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Identification { get; set; }

        /// <summary>
        /// Name of the Relic.
        /// </summary>
        [StringLength(50)]
        public string Designation { get; set; } //name

        /// <summary>
        /// Type of Relic, like archeotech/xenothech/heretekal.
        /// </summary>
        [StringLength(50)]
        public string Classification { get; set; } //type

        /// <summary>
        /// Description of the Relic.
        /// </summary>
        [StringLength(50)]
        public string Description { get; set; } //description

        /// <summary>
        /// Current state of damage of the Relic.
        /// </summary>
        [StringLength(50)]
        public string Status { get; set; } //State of the relic

        /// <summary>
        /// Records tied to or mentioning said Relic
        /// </summary>
        [NotMapped]
        public virtual ICollection<Record>? Records { get; set; }

        /// <summary>
        /// The Locíation tied to the current Relic.
        /// </summary>
        [NotMapped]
        public virtual Location? Location { get; set; }

        /// <summary>
        /// The Id of the Location tied to current Relic.
        /// </summary>
        [StringLength(50)]
        public string LocationIdentification { get; set; }
    }
}
