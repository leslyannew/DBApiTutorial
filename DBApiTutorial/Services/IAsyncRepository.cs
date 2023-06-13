namespace DBApiTutorial.Services
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        //Task<T> CreateAsync(T entity);
        //Task UpdateAsync(T entity);
        //Task DeleteAsync(T entity);
        //Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
    }
}
