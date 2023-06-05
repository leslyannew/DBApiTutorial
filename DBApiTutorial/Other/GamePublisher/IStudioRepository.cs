namespace DBApiTutorial.Other.GamePublisher
{
    public interface IStudioRepository
    {
        Task<IEnumerable<Studio>> GetStudiosAsync();
        Task<bool> StudioExists(int studioID);
        Task<Studio?> GetStudioAsync(int studioID);

    }
}
