using DBApiTutorial.Domain.Entity;

namespace DBApiTutorial.Domain
{
    public interface IOfficeRepository
    {
        Task<Office> GetOfficeByIdAsync(int id);
        Task<IReadOnlyList<Office>> GetOfficesAsync();

        // TODO: Office CUD Actions

        //Task<T> AddAsync(T entity);
        //Task UpdateAsync(T entity);
        //Task DeleteAsync(T entity);
    }
}
