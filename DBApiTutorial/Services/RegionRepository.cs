using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Services
{
    public class RegionRepository : IRegionRepository
    {
        private readonly CompanyDBContext _context;

        public RegionRepository(CompanyDBContext context)
        {
            _context = context;
        }

        public async Task<Region?> GetRegionByIdAsync(int id)
        {
            return await _context.Regions.Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Region>> GetRegionsAsync()
        {
            return await _context.Regions.OrderBy(r => r.Id).ToListAsync();
        }

        public async Task<bool> RegionExistsAsync(int regionId)
        {
            return await _context.Regions.AnyAsync(r => r.Id == regionId);
        }

        public async Task AddRegionAsync(Region region)
        {
            await _context.Regions.AddAsync(region);
        }

        public void DeleteRegion(Region region)
        {
            _context.Regions.Remove(region);
        }

        public async Task<bool> SaveChangesAsync()
        {
            //TODO : Change this 0?
            return await _context.SaveChangesAsync() >= 0;
        }

    }
}
