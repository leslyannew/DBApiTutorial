using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Domain
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly CompanyDBContext context;
        //private readonly RegionRepository regionRepository;

        public OfficeRepository(CompanyDBContext context)
        {
            this.context = context;
            //this.regionRepository = regionRepository;
        }

        public async Task<Office?> GetOfficeByIdAsync(int id)
        {
            return await context.Offices.Where(o => o.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Office>> GetOfficesAsync()
        {
            return await context.Offices.OrderBy(o => o.Id).ToListAsync();
        }

        public async Task AddOfficeAsync(Office office)
        {
            await context.Offices.AddAsync(office);
        }

        public async Task<bool> SaveChangesAsync()
        {
            //TODO : Change this 0?
            return await context.SaveChangesAsync() >= 0;
        }
    }
}
