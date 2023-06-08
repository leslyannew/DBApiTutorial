﻿using DBApiTutorial.Domain.Entity;

namespace DBApiTutorial.Domain
{
    public interface IRegionRepository
    {
        Task<Region> GetRegionByIdAsync(int id);
        Task<IReadOnlyList<Region>> GetRegionsAsync();

        // TODO: Region CUD Actions

        //Task<T> AddAsync(T entity);
        //Task UpdateAsync(T entity);
        //Task DeleteAsync(T entity);
    }
}
