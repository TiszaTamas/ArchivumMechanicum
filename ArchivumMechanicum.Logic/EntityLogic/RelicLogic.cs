using ArchivumMechanicum.Data;
using ArchivumMechanicum.Entities.Entity_Models;
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

        public RelicLogic(Repositorium<Relic> repositorium)
        {
            Repositorium = repositorium;
        }

        public void CreateRelic(Relic rel)
        {
            Relic l = rel;

            if (Repositorium.GetAll().FirstOrDefault(x => x.Designation == l.Designation) == null)
            {
                Repositorium.Create(l);
            }
            else
            {
                throw new ArgumentException("This Relic has already been stored in the Archivum.");
            }
        }

        public IEnumerable<Relic> ReadAllRelics()
        {

            return Repositorium.GetAll();
        }

        public void UpdateRelic(string id, Relic rel)
        {
            var old = Repositorium.FindById(id);
            old = rel;
            Repositorium.Update(old);
        }

        public void DeleteRelic(string id)
        {
            Repositorium.DeleteById(id);
        }

        public Relic GetRelicById(string id)
        {
            var rel = Repositorium.FindById(id);
            return rel;
        }
    }
}
