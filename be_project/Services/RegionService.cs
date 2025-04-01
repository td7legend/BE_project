using be_project.Models;
using be_project.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace be_project.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            return await _regionRepository.GetAllAsync();
        }

        public async Task<Region> GetRegionByIdAsync(int id)
        {
            return await _regionRepository.GetRegionWithLocationsAndDevices(id);
        }

        public async Task<Region> CreateRegionAsync(RegionDto regionDto)
        {
            // Tạo một đối tượng Region mới từ RegionDto
            var region = new Region
            {
                Name = regionDto.Name
            };
            // Thêm vào cơ sở dữ liệu
            return await _regionRepository.AddAsync(region);
        }


        public async Task<Region> UpdateRegionAsync(Region region)
        {
            return await _regionRepository.UpdateAsync(region);
        }

        public async Task<bool> DeleteRegionAsync(int id)
        {
            return await _regionRepository.DeleteAsync(id);
        }
    }
}
