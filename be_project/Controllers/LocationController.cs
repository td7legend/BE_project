using be_project.Models;
using be_project.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace be_project.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllLocations()
        {
            var locations = await _locationService.GetAllLocationsAsync();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocationById(int id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null)
                return NotFound();

            return Ok(location);
        }

        [HttpGet("region/{regionId}")]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocationsByRegionId(int regionId)
        {
            var locations = await _locationService.GetLocationsByRegionIdAsync(regionId);
            return Ok(locations);
        }

        [HttpPost]
        public async Task<ActionResult<Location>> CreateLocation(LocationDto location)
        {
            var createdLocation = await _locationService.AddLocationAsync(location);
            return CreatedAtAction(nameof(GetLocationById), new { id = createdLocation.Id }, createdLocation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, Location location)
        {
            if (id != location.Id)
                return BadRequest();

            var updatedLocation = await _locationService.UpdateLocationAsync(location);
            return Ok(updatedLocation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var deleted = await _locationService.DeleteLocationAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
