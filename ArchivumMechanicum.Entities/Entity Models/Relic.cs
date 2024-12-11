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
    public class Relic : IIdentityEntity
    {
        public Relic(string identification, string designation, string classification, string description, string status)
        {
            Identification = Guid.NewGuid().ToString();
            Designation = designation;
            Classification = classification;
            Description = description;
            Status = status;
        }

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
        /// The Location tied to the current Relic.
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
