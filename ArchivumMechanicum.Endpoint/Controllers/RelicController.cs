using ArchivumMechanicum.Entities.Entity_Models;
using ArchivumMechanicum.Logic.EntityLogic;
using Microsoft.AspNetCore.Mvc;

namespace ArchivumMechanicum.Endpoint.Controllers
{
    [Route("api/[controller]")]
    public class RelicController : Controller
    {
        RelicLogic logic;

        public RelicController(RelicLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        public void AddRelic(Relic rel)
        {
            logic.CreateRelic(rel);
        }

        [HttpGet]
        public IEnumerable<Relic> GetRelics()
        {
            return logic.ReadAllRelics();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            logic.DeleteRelic(id);
        }

        [HttpPut("{id}")]
        public void UpdateRelic(string id, Relic rel)
        {
            logic.UpdateRelic(id, rel);
        }

        [HttpGet("{id}")]
        public Relic GetRelic(string id)
        {
            return logic.GetRelicById(id);
        }
    }
}
