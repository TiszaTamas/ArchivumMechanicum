using ArchivumMechanicum.Data;
using ArchivumMechanicum.Entities.Dtos.LocationDtos;
using ArchivumMechanicum.Entities.Dtos.RecordDtos;
using ArchivumMechanicum.Entities.Dtos.RecordDtos;
using ArchivumMechanicum.Entities.Entity_Models;
using ArchivumMechanicum.Logic.Helpers;
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
        DtoProvider dtoProvider;

        public RecordLogic(Repositorium<Record> repositorium, DtoProvider dtoProvider)
        {
            Repositorium = repositorium;
            this.dtoProvider = dtoProvider;
        }

        public void CreateRecord(RecordCreateDto rec)
        {
            Record r = dtoProvider.Mapper.Map<Record>(rec);

            if (Repositorium.GetAll().FirstOrDefault(x => x.Title == r.Title) == null)
            {
                Repositorium.Create(r);
            }
            else
            {
                throw new ArgumentException("This Record has already been deposited in the Archivum.");
            }
        }

        public IEnumerable<RecordShortViewDto> ReadAllRecords()
        {

            return Repositorium.GetAll().Select(x =>
            dtoProvider.Mapper.Map<RecordShortViewDto>(x)
            );
        }

        public void UpdateRecord(string id, RecordUpdateDto rec)
        {
            var old = Repositorium.FindById(id);
            dtoProvider.Mapper.Map(rec, old);
            Repositorium.Update(old);
        }

        public void DeleteRecord(string id)
        {
            Repositorium.DeleteById(id);
        }

        public RecordViewDto GetRecordById(string id)
        {
            var rec = Repositorium.FindById(id);
            return dtoProvider.Mapper.Map<RecordViewDto>(rec);
        }

    }
}
