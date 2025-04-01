using be_project.Models;
using be_project.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace be_project.Controllers
{
    [Route("api/regions")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetAllRegions()
        {
            var regions = await _regionService.GetAllRegionsAsync();
            return Ok(regions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegionById(int id)
        {
            var region = await _regionService.GetRegionByIdAsync(id);
            if (region == null)
                return NotFound();
            return Ok(region);
        }

        [HttpPost]
        public async Task<ActionResult<Region>> CreateRegion([FromBody] RegionDto region)
        {
            var createdRegion = await _regionService.CreateRegionAsync(region);
            return CreatedAtAction(nameof(GetRegionById), new { id = createdRegion.Id }, createdRegion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegion(int id, [FromBody] Region region)
        {
            if (id != region.Id)
                return BadRequest("Region ID mismatch");

            var updatedRegion = await _regionService.UpdateRegionAsync(region);
            if (updatedRegion == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            var success = await _regionService.DeleteRegionAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
