﻿namespace InnoClinic.Services.Core.Abstractions
{
    public interface IRepositoryBase<T>
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
