using be_project.Models;
using be_project.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace be_project.Controllers
{
    [Route("api/devices")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetAllDevices()
        {
            var devices = await _deviceService.GetAllDevicesAsync();
            return Ok(devices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDeviceById(int id)
        {
            var device = await _deviceService.GetDeviceByIdAsync(id);
            if (device == null)
                return NotFound();

            return Ok(device);
        }

        [HttpGet("region/{regionId}")]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevicesByRegionId(int regionId)
        {
            var devices = await _deviceService.GetDevicesByRegionIdAsync(regionId);
            return Ok(devices);
        }

        [HttpPost]
        public async Task<ActionResult<Device>> CreateDevice(Device device)
        {
            var createdDevice = await _deviceService.AddDeviceAsync(device);
            return CreatedAtAction(nameof(GetDeviceById), new { id = createdDevice.Id }, createdDevice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(int id, Device device)
        {
            if (id != device.Id)
                return BadRequest();

            var updatedDevice = await _deviceService.UpdateDeviceAsync(device);
            return Ok(updatedDevice);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var deleted = await _deviceService.DeleteDeviceAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
