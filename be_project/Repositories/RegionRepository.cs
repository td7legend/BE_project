using be_project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace be_project.Repositories
{
    public class RegionRepository : GenericRepository<Region>, IRegionRepository
    {
        public RegionRepository(AppDbContext context) : base(context) { }

        public async Task<Region> GetRegionWithLocationsAndDevices(int id)
        {
            return await _context.Regions
                .Include(r => r.Locations)
                .Include(r => r.Devices)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
