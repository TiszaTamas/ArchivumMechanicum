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
        //        3. Table: Places/Planets
        //Current Variables:

        //name(good, perhaps location_name)
        //coordinates(keep)
        //current_controllers(rename custodians for theme)
        //Suggestions:

        //Rename table to Locations to generalize.
        //Add type (e.g., "planet," "space station," "moon").
        //Add sector or system(to group coordinates into broader regions).
        //Add significance(a note about its importance, e.g., "Forge World," "Xenos Site").

        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Identification {  get; set; }

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
