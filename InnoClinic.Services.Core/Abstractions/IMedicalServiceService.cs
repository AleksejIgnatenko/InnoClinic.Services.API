using InnoClinic.Services.Core.Models.MedicalServiceModels;

namespace InnoClinic.Services.Core.Abstractions;

/// <summary>
/// Interface for managing medical services.
/// </summary>
public interface IMedicalServiceService
{
    /// <summary>
    /// Creates a new medical service asynchronously.
    /// </summary>
    /// <param name="medicalServiceRequest">The request object containing details of the medical service to create.</param>
    Task CreateMedicalServiceAsync(MedicalServiceRequest medicalServiceRequest);

    /// <summary>
    /// Deletes a medical service asynchronously.
    /// </summary>
    /// <param name="id">The Id of the medical service to delete.</param>
    Task DeleteMedicalServiceAsync(Guid id);

    /// <summary>
    /// Retrieves all medical services asynchronously.
    /// </summary>
    /// <returns>A collection of all medical services.</returns>
    Task<IEnumerable<MedicalServiceEntity>> GetAllMedicalServiceAsync();

    /// <summary>
    /// Retrieves a medical service by its Id asynchronously.
    /// </summary>
    /// <param name="id">The Id of the medical service to retrieve.</param>
    /// <returns>The medical service entity corresponding to the Id.</returns>
    Task<MedicalServiceEntity> GetMedicalServiceByIdAsync(Guid id);

    /// <summary>
    /// Retrieves all active medical services asynchronously.
    /// </summary>
    /// <returns>A collection of all active medical services.</returns>
    Task<IEnumerable<MedicalServiceEntity>> GetAllActiveMedicalServicesAsync();

    /// <summary>
    /// Updates a medical service asynchronously.
    /// </summary>
    /// <param name="id">The Id of the medical service to update.</param>
    /// <param name="medicalServiceRequest">The request object containing updated information for the medical service.</param>
    Task UpdateMedicalServiceAsync(Guid id, MedicalServiceRequest medicalServiceRequest);

    /// <summary>
    /// Retrieves all medical services associated with a given specialization asynchronously.
    /// </summary>
    /// <param name="specializationId">The Id of the specialization to filter by.</param>
    /// <returns>A collection of medical services associated with the specialization.</returns>
    Task<IEnumerable<MedicalServiceEntity>> GetServicesBySpecializationIdAsync(Guid specializationId);
}