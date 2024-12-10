using ArchivumMechanicum.Entities.Dtos;
using ArchivumMechanicum.Entities.Entity_Models;
using ArchivumMechanicum.Logic.EntityLogic;
using Microsoft.AspNetCore.Mvc;

namespace ArchivumMechanicum.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        LocationLogic logic;

        public LocationController(LocationLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        public void AddLocation(LocationCreateDto loc)
        {
            logic.CreateLocation(loc);
        }

        [HttpGet]
        public IEnumerable<Location> GetLocations()
        {
            return logic.ReadAllLocations();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            logic.DeleteLocation(id);
        }

        [HttpPut("{id}")]
        public void UpdateLocation(string id, Location loc)
        {
            logic.UpdateLocation(id, loc);
        }

        [HttpGet("{id}")]
        public Location GetLocation(string id)
        {
            return logic.GetLocationById(id);
        }
    }
}
