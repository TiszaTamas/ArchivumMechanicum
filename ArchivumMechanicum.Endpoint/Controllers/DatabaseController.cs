using ArchivumMechanicum.Logic.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchivumMechanicum.Endpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly DatabseLogic Logic;

        public DatabaseController(DatabseLogic logic)
        {
            Logic = logic;
        }

        [HttpPost("populate")]
        public async Task<IActionResult> Populate()
        {
            try
            {
                await Logic.PopulateDatabaseAsync();
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

        [HttpDelete("purge the machine spirit")]
        [Authorize(Roles ="Admin")]
        public void ClearDatabase()
        {
            Logic.ClearDatabase();
        }
    }

}
