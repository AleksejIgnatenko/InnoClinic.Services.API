using InnoClinic.Services.Core.Models.SpecializationModel;

namespace InnoClinic.Services.Core.Abstractions;

/// <summary>
/// Interface for the specialization repository.
/// </summary>
public interface ISpecializationRepository : IBaseRepository<SpecializationEntity>
{
    /// <summary>
    /// Retrieves all active specializations asynchronously.
    /// </summary>
    /// <returns>A collection of all active specializations.</returns>
    Task<IEnumerable<SpecializationEntity>> GetAllActiveSpecializationsAsync();
}