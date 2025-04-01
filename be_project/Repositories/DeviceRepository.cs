using be_project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace be_project.Repositories
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Device>> GetDevicesByRegionIdAsync(int regionId)
        {
            return await _context.Devices.Where(d => d.RegionId == regionId).ToListAsync();
        }
    }
}
