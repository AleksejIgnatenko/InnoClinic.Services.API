using InnoClinic.Services.Core.Models.SpecializationModel;

namespace InnoClinic.Services.Core.Abstractions;

/// <summary>
/// Interface for managing specializations.
/// </summary>
public interface ISpecializationService
{
    /// <summary>
    /// Creates a new specialization asynchronously.
    /// </summary>
    /// <param name="specializationRequest">The specialization request containing the name and active status.</param>
    Task CreateSpecializationAsync(SpecializationRequest specializationRequest);

    /// <summary>
    /// Retrieves all specializations asynchronously.
    /// </summary>
    /// <returns>A collection of all specializations.</returns>
    Task<IEnumerable<SpecializationEntity>> GetAllSpecializationsAsync();

    /// <summary>
    /// Retrieves all active specializations asynchronously.
    /// </summary>
    /// <returns>A collection of all active specializations.</returns>
    Task<IEnumerable<SpecializationEntity>> GetAllActiveSpecializationsAsync();

    /// <summary>
    /// Retrieves a specialization by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the specialization to retrieve.</param>
    /// <returns>The specialization entity corresponding to the ID.</returns>
    Task<SpecializationEntity> GetSpecializationByIdAsync(Guid id);

    /// <summary>
    /// Updates a specialization asynchronously.
    /// </summary>
    /// <param name="id">The ID of the specialization to update.</param>
    /// <param name="specializationRequest">The specialization request containing the updated name and active status.</param>
    Task UpdateSpecializationAsync(Guid id, SpecializationRequest specializationRequest);

    /// <summary>
    /// Deletes a specialization asynchronously.
    /// </summary>
    /// <param name="id">The ID of the specialization to delete.</param>
    Task DeleteSpecializationAsync(Guid id);
}