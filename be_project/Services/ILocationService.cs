using be_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace be_project.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllLocationsAsync();
        Task<Location> GetLocationByIdAsync(int id);
        Task<IEnumerable<Location>> GetLocationsByRegionIdAsync(int regionId);
        Task<Location> AddLocationAsync(LocationDto location);
        Task<Location> UpdateLocationAsync(Location location);
        Task<bool> DeleteLocationAsync(int id);
    }
}
