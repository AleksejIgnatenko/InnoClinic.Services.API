using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Exceptions;
using InnoClinic.Services.Core.Models.MedicalServiceModels;
using InnoClinic.Services.DataAccess.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.Services.DataAccess.Repositories;

/// <summary>
/// Repository class for handling operations related to medical service entities.
/// </summary>
public class MedicalServiceRepository(InnoClinicServicesDbContext context) : BaseRepository<MedicalServiceEntity>(context), IMedicalServiceRepository
{
    /// <summary>
    /// Retrieves all medical services asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of all medical services.</returns>
    public override async Task<IEnumerable<MedicalServiceEntity>> GetAllAsync()
    {
        return await _context.MedicalServices
            .AsNoTracking()
            .Include(m => m.ServiceCategory)
            .Include(m => m.Specialization)
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves medical services by specialization Id asynchronously.
    /// </summary>
    /// <param name="specializationId">The Id of the specialization to filter by.</param>
    public async Task<IEnumerable<MedicalServiceEntity>> GetBySpecializationIdAsync(Guid specializationId)
    {
        return await _context.MedicalServices
            .AsNoTracking()
            .Where(s => s.Specialization.Id.Equals(specializationId))
            .Include(m => m.ServiceCategory)
            .Include(m => m.Specialization)
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves all active medical services asynchronously.
    /// </summary>
    /// <returns>A collection of active medical service entities.</returns>
    public async Task<IEnumerable<MedicalServiceEntity>> GetAllActiveMedicalServicesAsync()
    {
        return await _context.MedicalServices
            .AsNoTracking()
            .Where(m => m.IsActive)
            .Include(m => m.ServiceCategory)
            .Include(m => m.Specialization)
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves a medical service by ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the medical service to retrieve.</param>
    /// <returns>The medical service with the specified ID.</returns>
    public override async Task<MedicalServiceEntity> GetByIdAsync(Guid id)
    {
        return await _context.MedicalServices
        .Include(m => m.ServiceCategory)
        .Include(m => m.Specialization)
        .FirstOrDefaultAsync(m => m.Id.Equals(id))
        ?? throw new ExceptionWithStatusCode($"Service with Id '{id}' not found.", StatusCodes.Status404NotFound); ;
    }
}