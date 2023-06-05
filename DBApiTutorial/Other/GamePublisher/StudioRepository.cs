//using Microsoft.EntityFrameworkCore;

//namespace DBApiTutorial.GamePublisher
//{
//    public class StudioRepository : IStudioRepository
//    {
//        private readonly GamePubDbContext context;

//        public StudioRepository(GamePubDbContext context)
//        {
//            this.context = context;
//        }


//        public async Task<IEnumerable<Studio>> GetStudiosAsync()
//        {
//            return await context.Studios.OrderBy(c => c.Name).ToListAsync();
//        }

//        public async Task<Studio?> GetStudioAsync(int studioId)
//        {
//            return await context.Studios.Where(s => s.Id == studioId).FirstOrDefaultAsync();
//        }

//        public async Task<bool> StudioExists(int studioId)
//        {
//            return await context.Studios.AnyAsync(s => s.Id == studioId);
//        }
//    }
//}
