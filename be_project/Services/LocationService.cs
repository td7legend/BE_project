using be_project.Models;
using be_project.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace be_project.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return await _locationRepository.GetAllAsync();
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            return await _locationRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Location>> GetLocationsByRegionIdAsync(int regionId)
        {
            return await _locationRepository.GetLocationsByRegionIdAsync(regionId);
        }

        public async Task<Location> AddLocationAsync(LocationDto locationDto)
        {
            if (string.IsNullOrEmpty(locationDto.Name))
            {
                throw new ArgumentException("Location name cannot be null or empty");
            }

            var location = new Location
            {
                Name = locationDto.Name,
                RegionId = locationDto.RegionId 
            };

            return await _locationRepository.AddAsync(location);
        }

        public async Task<Location> UpdateLocationAsync(Location location)
        {
            return await _locationRepository.UpdateAsync(location);
        }

        public async Task<bool> DeleteLocationAsync(int id)
        {
            return await _locationRepository.DeleteAsync(id);
        }
    }
}
