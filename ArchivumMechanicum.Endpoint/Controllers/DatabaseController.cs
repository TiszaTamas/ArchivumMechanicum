using ArchivumMechanicum.Logic.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ArchivumMechanicum.Endpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly DatabaseSeeder Seeder;

        public DatabaseController(DatabaseSeeder seeder)
        {
            Seeder = seeder;
        }

        [HttpPost("populate")]
        public async Task<IActionResult> Populate()
        {
            try
            {
                await Seeder.PopulateDatabaseAsync();
                return Ok("Database populated successfully!");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
