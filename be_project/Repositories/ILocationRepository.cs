using be_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace be_project.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<IEnumerable<Location>> GetLocationsByRegionIdAsync(int regionId);
    }
}
