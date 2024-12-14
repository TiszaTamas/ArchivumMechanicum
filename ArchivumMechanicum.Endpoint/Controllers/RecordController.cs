using ArchivumMechanicum.Entities.Dtos.RecordDtos;
using ArchivumMechanicum.Entities.Entity_Models;
using ArchivumMechanicum.Logic.EntityLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchivumMechanicum.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : Controller
    {
        RecordLogic logic;

        public RecordController(RecordLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        [Authorize]
        public void AddRecord(RecordCreateDto rec)
        {
            logic.CreateRecord(rec);
        }

        [HttpGet]
        public IEnumerable<RecordShortViewDto> GetRecords()
        {
            return logic.ReadAllRecords();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(string id)
        {
            logic.DeleteRecord(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public void UpdateRecord(string id, RecordUpdateDto rec)
        {
            logic.UpdateRecord(id, rec);
        }

        [HttpGet("{id}")]
        public RecordViewDto GetRecord(string id)
        {
            return logic.GetRecordById(id);
        }
    }
}
