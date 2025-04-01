using be_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace be_project.Services
{
    public interface IDeviceService
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync();
        Task<Device> GetDeviceByIdAsync(int id);
        Task<IEnumerable<Device>> GetDevicesByRegionIdAsync(int regionId);
        Task<Device> AddDeviceAsync(Device device);
        Task<Device> UpdateDeviceAsync(Device device);
        Task<bool> DeleteDeviceAsync(int id);
    }
}
