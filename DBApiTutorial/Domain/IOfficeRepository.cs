using DBApiTutorial.Domain.Entity;

namespace DBApiTutorial.Domain
{
    public interface IOfficeRepository
    {
        Task<Office?> GetOfficeByIdAsync(int officeId);
        Task<IReadOnlyList<Office>> GetOfficesAsync();

        // TODO: Office CUD Actions

        Task AddOfficeAsync(Office office);
        Task<bool> SaveChangesAsync();
        //Task UpdateAsync(T entity);
        //Task DeleteAsync(T entity);
    }
}
