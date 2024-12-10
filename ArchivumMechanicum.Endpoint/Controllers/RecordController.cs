using ArchivumMechanicum.Entities.Entity_Models;
using ArchivumMechanicum.Logic.EntityLogic;
using Microsoft.AspNetCore.Mvc;

namespace ArchivumMechanicum.Endpoint.Controllers
{
    [Route("api/[controller]")]
    public class RecordController : Controller
    {
        RecordLogic logic;

        public RecordController(RecordLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        public void AddRecord(Record rec)
        {
            logic.CreateRecord(rec);
        }

        [HttpGet]
        public IEnumerable<Record> GetRecords()
        {
            return logic.ReadAllRecords();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            logic.DeleteRecord(id);
        }

        [HttpPut("{id}")]
        public void UpdateRecord(string id, Record rec)
        {
            logic.UpdateRecord(id, rec);
        }

        [HttpGet("{id}")]
        public Record GetRecord(string id)
        {
            return logic.GetRecordById(id);
        }
    }
}
