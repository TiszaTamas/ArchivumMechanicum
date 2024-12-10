using ArchivumMechanicum.Data;
using ArchivumMechanicum.Entities.Entity_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Logic.EntityLogic
{
    public class RecordLogic
    {
        Repositorium<Record> Repositorium;

        public RecordLogic(Repositorium<Record> repositorium)
        {
            Repositorium = repositorium;
        }

        public void CreateRecord(Record rec)
        {
            Record r = rec;

            if (Repositorium.GetAll().FirstOrDefault(x => x.Title == r.Title) == null)
            {
                Repositorium.Create(r);
            }
            else
            {
                throw new ArgumentException("This Record has already been deposited in the Archivum.");
            }
        }

        public IEnumerable<Record> ReadAllRecords()
        {

            return Repositorium.GetAll();
        }

        public void UpdateRecord(string id, Record rec)
        {
            var old = Repositorium.FindById(id);
            old = rec;
            Repositorium.Update(old);
        }

        public void DeleteRecord(string id)
        {
            Repositorium.DeleteById(id);
        }

        public Record GetRecordById(string id)
        {
            var rec = Repositorium.FindById(id);
            return rec;
        }
    }
}
