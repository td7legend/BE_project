using be_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace be_project.Services
{
    public interface IRegionService
    {
        Task<IEnumerable<Region>> GetAllRegionsAsync();
        Task<Region> GetRegionByIdAsync(int id);
        Task<Region> CreateRegionAsync(RegionDto region);
        Task<Region> UpdateRegionAsync(Region region);
        Task<bool> DeleteRegionAsync(int id);
    }
}
