using be_project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace be_project.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Location>> GetLocationsByRegionIdAsync(int regionId)
        {
            return await _context.Locations
                .Where(l => l.RegionId == regionId)
                .ToListAsync();
        }
    }
}
