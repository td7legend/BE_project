using be_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace be_project.Repositories
{
    public interface IRegionRepository : IRepository<Region>
    {
        Task<Region> GetRegionWithLocationsAndDevices(int id);
    }
}
