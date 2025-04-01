using be_project.Models;
using be_project.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace be_project.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            return await _deviceRepository.GetAllAsync();
        }

        public async Task<Device> GetDeviceByIdAsync(int id)
        {
            return await _deviceRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Device>> GetDevicesByRegionIdAsync(int regionId)
        {
            return await _deviceRepository.GetDevicesByRegionIdAsync(regionId);
        }

        public async Task<Device> AddDeviceAsync(Device device)
        {
            return await _deviceRepository.AddAsync(device);
        }

        public async Task<Device> UpdateDeviceAsync(Device device)
        {
            return await _deviceRepository.UpdateAsync(device);
        }

        public async Task<bool> DeleteDeviceAsync(int id)
        {
            return await _deviceRepository.DeleteAsync(id);
        }
    }
}
