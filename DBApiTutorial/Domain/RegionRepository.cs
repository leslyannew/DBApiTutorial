using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Domain
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

        // TODO: Region CUD Actions

        public async Task AddRegionAsync(Region region)
        {
            await context.Regions.AddAsync(region);
        }

        public async Task<bool> SaveChangesAsync()
        {
            //TODO : Change this 0?
            return await context.SaveChangesAsync() >= 0;
        }

        //public Task UpdateAsync(Region entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task DeleteAsync(Region entity)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
