using ArchivumMechanicum.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArchivumMechanicum.Entities.Entity_Models
{
    public class Location : IIdentityEntity
    {
        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Identification {  get; set; }

        public Location()
        {
        }

        public Location(string sector, string name, string significance, string coordinates, string custodian)
        {
            Identification = Guid.NewGuid().ToString();
            Sector = sector;
            Name = name;
            Significance = significance;
            Coordinates = coordinates;
            Custodian = custodian;
        }

        [StringLength(50)]
        public string Sector {  get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Significance { get; set; }

        [StringLength(50)]
        public string Coordinates { get; set; }

        [StringLength(50)]
        public string Custodian { get; set; }

        [NotMapped]
        public virtual ICollection<Relic>? Relics { get; set; }

        [NotMapped]
        public virtual ICollection<Record>? Records { get; set; }
    }
}
