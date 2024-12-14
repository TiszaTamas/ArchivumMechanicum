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
    public class Record : IIdentityEntity
    {
        public Record(string identification, string title, string inscription,string scribe, string condition, string classification, string archivingDate)
        {
            Identification = Guid.NewGuid().ToString();
            Title = title;
            Inscription = inscription;
            Scribe = scribe;
            Condition = condition;
            Classification = classification;
            ArchivingDate = archivingDate;
        }

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
        public string? Condition { get; set; }

        [StringLength(50)]
        public string? Classification { get; set; }

        [StringLength(50)]
        public string? ArchivingDate { get; set; }

        [NotMapped]
        public virtual Relic? Relic { get; set; }

        [StringLength(50)]
        public string RelicIdentification { get; set; }

        [NotMapped]
        public virtual Location? Location { get; set; }

        [StringLength(50)]
        public string LocationIdentification { get; set; }

        public Record()
        {
                
        }
    }
}
