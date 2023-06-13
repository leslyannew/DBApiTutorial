using DBApiTutorial.Domain.Entity;

namespace DBApiTutorial.Services
{
    public interface IRegionRepository
    {
        Task<Region?> GetRegionByIdAsync(int id);
        Task<IReadOnlyList<Region>> GetRegionsAsync();
        Task<bool> RegionExistsAsync(int regionId);

        // TODO: Region UD Actions

        Task AddRegionAsync(Region region);
        Task<bool> SaveChangesAsync();
        //Task UpdateAsync(T entity);
        //Task DeleteAsync(T entity);
    }
}
