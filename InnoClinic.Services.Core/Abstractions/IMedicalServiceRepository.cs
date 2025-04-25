using InnoClinic.Services.Core.Models.MedicalServiceModels;

namespace InnoClinic.Services.Core.Abstractions;

/// <summary>
/// Interface for the medical service repository.
/// </summary>
public interface IMedicalServiceRepository : IBaseRepository<MedicalServiceEntity>
{
    /// <summary>
    /// Retrieves all active medical services asynchronously.
    /// </summary>
    /// <returns>A collection of all active medical services.</returns>
    Task<IEnumerable<MedicalServiceEntity>> GetAllActiveMedicalServicesAsync();

    /// <summary>
    /// Retrieves medical services by specialization ID asynchronously.
    /// </summary>
    /// <param name="specializationId">The ID of the specialization to filter by.</param>
    /// <returns>A collection of medical services associated with the specialization ID.</returns>
    Task<IEnumerable<MedicalServiceEntity>> GetBySpecializationIdAsync(Guid specializationId);
}