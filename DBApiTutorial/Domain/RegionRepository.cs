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

        public async Task<Region?> GetByIdAsync(int id)
        {
            return await context.Regions.Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Region>> ListAllAsync()
        {
            return await context.Regions.OrderBy(r => r.Name).ToListAsync();
        }

        // TODO: CUD Action

        //public Task<Region> AddAsync(Region entity)
        //{
        //    throw new NotImplementedException();
        //}

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
