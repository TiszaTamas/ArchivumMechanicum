using ArchivumMechanicum.Data;
using ArchivumMechanicum.Entities.Dtos.RelicDtos;
using ArchivumMechanicum.Entities.Entity_Models;
using ArchivumMechanicum.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Logic.EntityLogic
{
    public class RelicLogic
    {
        Repositorium<Relic> Repositorium;
        DtoProvider dtoProvider;

        public RelicLogic(Repositorium<Relic> repositorium, DtoProvider dtoProvider)
        {
            Repositorium = repositorium;
            this.dtoProvider = dtoProvider;
        }

        public void CreateRelic(RelicCreateDto rel)
        {
            Relic r = dtoProvider.Mapper.Map<Relic>(rel);

            if (Repositorium.GetAll().FirstOrDefault(x => x.Designation== r.Designation) == null)
            {
                Repositorium.Create(r);
            }
            else
            {
                throw new ArgumentException("This Relic has already been stored in the Archivum.");
            }
        }

        public IEnumerable<RelicShortViewDto> ReadAllRelics()
        {

            return Repositorium.GetAll().Select(x =>
            dtoProvider.Mapper.Map<RelicShortViewDto>(x)
            );
        }

        public void UpdateRelic(string id, RelicUpdateDto rel)
        {
            var old = Repositorium.FindById(id);
            dtoProvider.Mapper.Map(rel, old);
            Repositorium.Update(old);
        }

        public void DeleteRelic(string id)
        {
            Repositorium.DeleteById(id);
        }

        public RelicViewDto GetRelicById(string id)
        {
            var rel = Repositorium.FindById(id);
            return dtoProvider.Mapper.Map<RelicViewDto>(rel);
        }
    }
}
