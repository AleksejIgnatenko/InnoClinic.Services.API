using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Exceptions;
using InnoClinic.Services.Core.Models.SpecializationModel;
using InnoClinic.Services.DataAccess.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.Services.DataAccess.Repositories;

/// <summary>
/// Repository for handling operations related to specializations.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="SpecializationRepository"/> class.
/// </remarks>
/// <param name="context">The database context.</param>
public class SpecializationRepository(InnoClinicServicesDbContext context) : BaseRepository<SpecializationEntity>(context), ISpecializationRepository
{

    /// <summary>
    /// Retrieves all specializations asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of all specializations.</returns>
    public override async Task<IEnumerable<SpecializationEntity>> GetAllAsync()
    {
        return await _context.Specializations
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves all active specializations asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of all active specializations.</returns>
    public async Task<IEnumerable<SpecializationEntity>> GetAllActiveSpecializationsAsync()
    {
        return await _context.Specializations
            .AsNoTracking()
            .Where(s => s.IsActive)
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves a specialization by its Id asynchronously.
    /// </summary>
    /// <param name="id">The Id of the specialization to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the specialization entity.</returns>
    public override async Task<SpecializationEntity> GetByIdAsync(Guid id)
    {
        return await _context.Specializations
            .FirstOrDefaultAsync(s => s.Id.Equals(id))
            ?? throw new ExceptionWithStatusCode($"Specialization with Id '{id}' not found.", StatusCodes.Status404NotFound);
    }
}