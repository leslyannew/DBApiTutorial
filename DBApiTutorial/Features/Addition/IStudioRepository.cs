using DBApiTutorial.Domain.Entity;

namespace DBApiTutorial.Features.Addition
{
    public interface IStudioRepository
    {
        Task<IEnumerable<Studio>> GetStudiosAsync();
        Task<bool> StudioExists(int studioID);
        Task<Studio> GetStudioAsync(int studioID);
        
    }
}
