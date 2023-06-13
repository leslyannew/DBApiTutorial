using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Services
{
    public class RegionRepository : IRegionRepository
    {
        private readonly CompanyDBContext context;

        public RegionRepository(CompanyDBContext context)
        {
            this.context = context;
        }

        public async Task<Region?> GetRegionByIdAsync(int id)
        {
            return await context.Regions.Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Region>> GetRegionsAsync()
        {
            return await context.Regions.OrderBy(r => r.Id).ToListAsync();
        }

        public async Task<bool> RegionExistsAsync(int regionId)
        {
            return await context.Regions.AnyAsync(r => r.Id == regionId);
        }

        // TODO: Region UD Actions

        public async Task AddRegionAsync(Region region)
        {
            await context.Regions.AddAsync(region);
        }

        //public Task UpdateAsync(Region region)
        //{
            
        //}

        //public Task DeleteAsync(Region entity)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> SaveChangesAsync()
        {
            //TODO : Change this 0?
            return await context.SaveChangesAsync() >= 0;
        }

    }
}
