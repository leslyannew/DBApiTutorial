using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Addition
{
    public class StudioRepository : IStudioRepository
    {
        private readonly GamePubDbContext context;

        public StudioRepository(GamePubDbContext context)
        {
            this.context = context;
        }

        public Task<IEnumerable<Studio>> GetStudiosAsync()
        {
            return await context.Studios.OrderBy(c => c.Name).ToListAsync();
        }

        public Task<Studio> GetStudioAsync(int studioID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> StudioExists(int studioID)
        {
            throw new NotImplementedException();
        }
    }
}
