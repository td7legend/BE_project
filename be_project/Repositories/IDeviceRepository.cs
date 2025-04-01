using be_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace be_project.Repositories
{
    public interface IDeviceRepository : IRepository<Device>
    {
        Task<IEnumerable<Device>> GetDevicesByRegionIdAsync(int regionId);
    }
}
