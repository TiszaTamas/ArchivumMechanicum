using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ArchivumMechanicum.Entities.Helpers;

namespace ArchivumMechanicum.Entities.Entity_Models
{
    public class Record : IdentityEntity
    {
        //        2. Table: Records
        //Current Variables:

        //name(good, perhaps record_title for specificity)
        //information(rename content or inscription for brevity and flavor)
        //time_of_creation(rename archiving_date or creation_epoch for thematic consistency)
        //Suggestions:

        //Add author or scribe(who recorded the information)
        //Add condition(e.g., "complete," "fragmentary")
        //Add classification(to tag types of records, e.g., decree, blueprint, field report)

        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Identification {  get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Inscription { get; set; }

        [StringLength(50)]
        public string Scribe { get; set; }

        [StringLength(50)]
        public string Condition { get; set; }

        [StringLength(50)]
        public string Classification { get; set; }

        [StringLength(50)]
        public string ArchivingDate { get; set; }

        [NotMapped]
        public virtual Relic? Relic { get; set; }

        [StringLength(50)]
        public string RelicIdentification { get; set; }
    }
}
