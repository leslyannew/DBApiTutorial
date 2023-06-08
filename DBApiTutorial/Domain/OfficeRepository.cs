using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Domain
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly CompanyDBContext context;

        public OfficeRepository(CompanyDBContext context)
        {
            this.context = context;
        }

        public async Task<Office?> GetOfficeByIdAsync(int id)
        {
            return await context.Offices.Where(o => o.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Office>> GetOfficesAsync()
        {
            return await context.Offices.OrderBy(o => o.Id).ToListAsync();
        }
    }
}
