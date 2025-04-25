using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Models;
using InnoClinic.Services.DataAccess.Context;

namespace InnoClinic.Services.DataAccess.Repositories;

/// <summary>
/// Base repository class providing common CRUD operations for entities.
/// </summary>
/// <typeparam name="T">The type of entity handled by the repository.</typeparam>
public abstract class BaseRepository<T>(InnoClinicServicesDbContext context) : IBaseRepository<T> where T : EntityBase
{
    protected readonly InnoClinicServicesDbContext _context = context;

    /// <summary>
    /// Creates a new entity of type T asynchronously.
    /// </summary>
    /// <param name="entity">The entity to be created.</param>
    public async Task CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves all entities of type T asynchronously.
    /// </summary>
    /// <returns>An enumerable collection of entities of type T.</returns>
    public abstract Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Retrieves an entity of type T by its Id asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <returns>The entity with the specified Id.</returns>
    public abstract Task<T> GetByIdAsync(Guid id);

    /// <summary>
    /// Update entity of type T asynchronously.
    /// </summary>
    /// <param name="entity">The entity to be updated.</param>
    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Delete entity of type T asynchronously.
    /// </summary>
    /// <param name="entity">The entity to be deleted.</param>
    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}