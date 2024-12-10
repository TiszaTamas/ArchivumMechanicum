using ArchivumMechanicum.Data;
using ArchivumMechanicum.Entities.Dtos;
using ArchivumMechanicum.Entities.Entity_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Logic.EntityLogic
{
    public class LocationLogic
    {
        Repositorium<Location> Repositorium;

        public LocationLogic(Repositorium<Location> repositorium)
        {
            this.Repositorium = repositorium;
        }

        public void CreateLocation(LocationCreateDto loc)
        {
            var l = new Location()
            {
                Name = loc.Name,
                Sector = loc.Sector,
                Custodian = loc.Custodian,
            };

            if (Repositorium.GetAll().FirstOrDefault(x => x.Name == l.Name) == null)
            {
                Repositorium.Create(l);
            }
            else
            {
                throw new ArgumentException("This Location has already been recorded in the Archivum.");
            }
        }

        public IEnumerable<Location> ReadAllLocations()
        {

            return Repositorium.GetAll();
        }

        public void UpdateLocation(string id,Location loc)
        {
            var old= Repositorium.FindById(id);
            old = loc;
            Repositorium.Update(old);
        }

        public void DeleteLocation(string id)
        {
            Repositorium.DeleteById(id);
        }

        public Location GetLocationById(string id)
        {
            var loc = Repositorium.FindById(id);
            return loc;
        }
    }


}
