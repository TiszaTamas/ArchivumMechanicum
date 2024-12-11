using ArchivumMechanicum.Data;
using ArchivumMechanicum.Entities.Dtos.LocationDtos;
using ArchivumMechanicum.Entities.Entity_Models;
using ArchivumMechanicum.Entities.Helpers;
using ArchivumMechanicum.Logic.Helpers;
using Microsoft.EntityFrameworkCore;
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
        DtoProvider dtoProvider;

        public LocationLogic(Repositorium<Location> repositorium, DtoProvider dtoProvider)
        {
            this.Repositorium = repositorium;
            this.dtoProvider = dtoProvider;
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

        public IEnumerable<LocationShortViewDto> ReadAllLocations()
        {

            return Repositorium.GetAll().Select(x=>
            dtoProvider.Mapper.Map<LocationShortViewDto>(x)
            );
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
