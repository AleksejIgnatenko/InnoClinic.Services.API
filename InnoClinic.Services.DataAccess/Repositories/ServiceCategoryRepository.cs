using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Exceptions;
using InnoClinic.Services.Core.Models.ServiceCategoryModels;
using InnoClinic.Services.DataAccess.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.Services.DataAccess.Repositories;

/// <summary>
/// Repository for handling operations related to service categories.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ServiceCategoryRepository"/> class.
/// </remarks>
/// <param name="context">The database context.</param>
public class ServiceCategoryRepository(InnoClinicServicesDbContext context) : BaseRepository<ServiceCategoryEntity>(context), IServiceCategoryRepository
{

    /// <summary>
    /// Retrieves all service categories asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of all service categories.</returns>
    public override async Task<IEnumerable<ServiceCategoryEntity>> GetAllAsync()
    {
        return await _context.ServiceCategories
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves a service category by its Id asynchronously.
    /// </summary>
    /// <param name="id">The Id of the service category to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the service category entity.</returns>
    public override async Task<ServiceCategoryEntity> GetByIdAsync(Guid id)
    {
        return await _context.ServiceCategories
            .FirstOrDefaultAsync(s => s.Id.Equals(id))
            ?? throw new ExceptionWithStatusCode($"Service category with Id '{id}' not found.", StatusCodes.Status404NotFound);
    }
}