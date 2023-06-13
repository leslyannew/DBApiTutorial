using DBApiTutorial.Domain.Entity;

namespace DBApiTutorial.Services
{
    public interface IRegionRepository
    {
        Task<Region?> GetRegionByIdAsync(int id);
        Task<IReadOnlyList<Region>> GetRegionsAsync();
        Task<bool> RegionExistsAsync(int id);
        Task AddRegionAsync(Region region);
        Task<bool> SaveChangesAsync();
        public void DeleteRegion(Region region);
    }
}
