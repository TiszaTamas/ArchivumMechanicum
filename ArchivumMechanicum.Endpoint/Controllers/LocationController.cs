using ArchivumMechanicum.Entities.Dtos.LocationDtos;
using ArchivumMechanicum.Entities.Entity_Models;
using ArchivumMechanicum.Logic.EntityLogic;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public void AddLocation(LocationCreateDto loc)
        {
            logic.CreateLocation(loc);
        }

        [HttpGet]
        public IEnumerable<LocationShortViewDto> GetLocations()
        {
            return logic.ReadAllLocations();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public void Delete(string id)
        {
            logic.DeleteLocation(id);
        }

        [HttpPut("{id}")]
        [Authorize]
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
