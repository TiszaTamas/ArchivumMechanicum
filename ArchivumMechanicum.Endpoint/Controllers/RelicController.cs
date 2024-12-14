using ArchivumMechanicum.Entities.Dtos.RelicDtos;
using ArchivumMechanicum.Entities.Entity_Models;
using ArchivumMechanicum.Logic.EntityLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchivumMechanicum.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelicController : Controller
    {
        RelicLogic logic;

        public RelicController(RelicLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        [Authorize]
        public void AddRelic(RelicCreateDto rel)
        {
            logic.CreateRelic(rel);
        }

        [HttpGet]
        public IEnumerable<RelicShortViewDto> GetRelics()
        {
            return logic.ReadAllRelics();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(string id)
        {
            logic.DeleteRelic(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public void UpdateRelic(string id, RelicUpdateDto rel)
        {
            logic.UpdateRelic(id, rel);
        }

        [HttpGet("{id}")]
        public RelicViewDto GetRelic(string id)
        {
            return logic.GetRelicById(id);
        }
    }
}
